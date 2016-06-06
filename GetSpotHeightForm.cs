using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetSpotHeights
{
    public partial class GetSpotHeightForm : Form
    {
        string attributeTagName = "";
        string blockName = "";
        double blockScale = 1;
        double intervalPline = 0.5; 
        PromptEntityResult prmtEnt;

        public GetSpotHeightForm(PromptEntityResult prmtEntIncoming)
        {
            InitializeComponent();
            prmtEnt = prmtEntIncoming;
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                DBObject obj = tr.GetObject(prmtEnt.ObjectId, OpenMode.ForRead);
                Polyline3d polyline = obj as Polyline3d;
                decimal lngth = Math.Round(Convert.ToDecimal(polyline.Length), 2);
                plineLengthLabel.Text = lngth.ToString();
            }
        }

        private void plotButton_Click(object sender, EventArgs e)
        {
            int blockCount = 0;
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;
            intervalPline = Convert.ToDouble(textBox2.Text);
            Database blockDB = new Database(true, true);
            ObjectId insertedBlockId;
            try
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    double lengthToNextVertex = 0;
                    DBObject obj = tr.GetObject(prmtEnt.ObjectId, OpenMode.ForRead);
                    Polyline3d polyline = obj as Polyline3d;
                    if (polyline != null)
                    {
                        List<ObjectId> vertices = new List<ObjectId>();
                        foreach(ObjectId id in polyline)
                        {
                            vertices.Add(id);
                        }
                        for (int i = 0; i < vertices.Count - 1; i++)
                        {
                            
                            PolylineVertex3d vertex = tr.GetObject(vertices[i], OpenMode.ForRead) as PolylineVertex3d;
                            PolylineVertex3d nextVertex = tr.GetObject(vertices[i + 1], OpenMode.ForRead) as PolylineVertex3d;
                            BlockTable blockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                            Double length = vertex.Position.DistanceTo(nextVertex.Position);
                            lengthToNextVertex += length;
                            if (checkEveryVertext.CheckState != CheckState.Checked)
                            {
                                while (lengthToNextVertex >= intervalPline)
                                {
                                    Point3d pt = GetPt(vertex.Position, nextVertex.Position, intervalPline - (lengthToNextVertex - length));
                                    lengthToNextVertex -= intervalPline;
                                    if (blockTable.Has(blockName))
                                    {
                                        BlockTableRecord blockTableRecord = blockTable[blockName].GetObject(OpenMode.ForRead) as BlockTableRecord;
                                        if (blockTable != null)
                                        {
                                                using (BlockReference spotHeight = new BlockReference(pt, blockTableRecord.ObjectId))
                                                {
                                                    blockCount++;
                                                    using (DocumentLock doclock = doc.LockDocument())
                                                    {
                                                        spotHeight.ScaleFactors = new Autodesk.AutoCAD.Geometry.Scale3d(blockScale, blockScale, blockScale);
                                                        BlockTableRecord blocktableRec = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                                                        blocktableRec.AppendEntity(spotHeight);
                                                        tr.AddNewlyCreatedDBObject(spotHeight, true);
                                                        insertedBlockId = spotHeight.ObjectId;
                                                        foreach (ObjectId attrID in blockTableRecord)
                                                        {
                                                            DBObject atttObj = attrID.GetObject(OpenMode.ForRead);
                                                            AttributeDefinition attrib = atttObj as AttributeDefinition;
                                                            if ((attrib != null) && (!attrib.Constant))
                                                            {
                                                                using (AttributeReference attributeRef = new AttributeReference())
                                                                {
                                                                    attributeRef.SetAttributeFromBlock(attrib, spotHeight.BlockTransform);
                                                                    attributeRef.TextString = Decimal.Round(Convert.ToDecimal(spotHeight.Position.Z), 2, MidpointRounding.AwayFromZero).ToString();

                                                                    spotHeight.AttributeCollection.AppendAttribute(attributeRef);
                                                                    tr.AddNewlyCreatedDBObject(attributeRef, true);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (blockTable.Has(blockName))
                                {
                                    BlockTableRecord blockTableRecord = blockTable[blockName].GetObject(OpenMode.ForRead) as BlockTableRecord;
                                    if (blockTable != null)
                                    {
                                            using (BlockReference spotHeight = new BlockReference(vertex.Position, blockTableRecord.ObjectId))
                                            {
                                                blockCount++;
                                                using (DocumentLock doclock = doc.LockDocument())
                                                {
                                                    spotHeight.ScaleFactors = new Autodesk.AutoCAD.Geometry.Scale3d(blockScale, blockScale, blockScale);
                                                    BlockTableRecord blocktableRec = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                                                    blocktableRec.AppendEntity(spotHeight);
                                                    tr.AddNewlyCreatedDBObject(spotHeight, true);
                                                    insertedBlockId = spotHeight.ObjectId;
                                                    foreach (ObjectId attrID in blockTableRecord)
                                                    {
                                                        DBObject atttObj = attrID.GetObject(OpenMode.ForRead);
                                                        AttributeDefinition attrib = atttObj as AttributeDefinition;
                                                        if ((attrib != null) && (!attrib.Constant))
                                                        {
                                                            using (AttributeReference attributeRef = new AttributeReference())
                                                            {
                                                                attributeRef.SetAttributeFromBlock(attrib, spotHeight.BlockTransform);
                                                                attributeRef.TextString = Decimal.Round(Convert.ToDecimal(spotHeight.Position.Z), 2, MidpointRounding.AwayFromZero).ToString();

                                                                spotHeight.AttributeCollection.AppendAttribute(attributeRef);
                                                                tr.AddNewlyCreatedDBObject(attributeRef, true);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        
                                    }
                                }
                            }
                        }

                        tr.Commit();
                    }
                    ed.Regen();
                    this.Close();
                    ed.WriteMessage("Successfully added {0} instances of block {1}", blockCount, blockName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private Point3d GetPt(Point3d ptStart, Point3d ptEnd, double divisor)
        {
            Line3d line = new Line3d(ptStart, ptEnd);
            Point3d pt = line.EvaluatePoint(divisor);
            return pt;
        }

        private double GetLength(Point3d ptStart, Point3d ptEnd)
        {
            LineSegment3d line = new LineSegment3d(ptStart, ptEnd);
            return line.Length;
        }
        private void blockDwgBtn_Click(object sender, EventArgs e)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;
            this.Hide();
            PromptEntityOptions prmtOpt = new PromptEntityOptions("\n\nSelect block");

            prmtOpt.SetRejectMessage("\n\nCan only select a block definition");
            prmtOpt.AddAllowedClass(typeof(BlockReference), false);
            PromptEntityResult result = ed.GetEntity(prmtOpt);
            if(result.Status == PromptStatus.OK)
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    BlockReference blkReference = tr.GetObject(result.ObjectId, OpenMode.ForRead) as BlockReference;
                    BlockTableRecord blockRecord = null;
                    if(blkReference.IsDynamicBlock)
                    {
                        blockRecord = tr.GetObject(blkReference.DynamicBlockTableRecord, OpenMode.ForRead) as BlockTableRecord;                        
                    }
                    else
                    {
                        blockRecord = tr.GetObject(blkReference.BlockTableRecord, OpenMode.ForRead) as BlockTableRecord;
                    }
                    blockName = blockRecord.Name;
                    blockDwgBtn.Text = blockRecord.Name;
                    this.Show();
                    this.Focus();
                    plotButton.Enabled = true;
                }
            }
        }

        private void blockScaleTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void blockScaleTxtBox_Leave(object sender, EventArgs e)
        {
            if(double.TryParse(blockScaleTxtBox.Text, out blockScale))
            {

            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(blockScaleTxtBox.Text, out intervalPline))
            {

            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void checkEveryVertext_CheckedChanged(object sender, EventArgs e)
        {
            if(checkEveryVertext.CheckState == CheckState.Checked)
            {
                textBox2.Enabled = false;
            }
            else
            {
                textBox2.Enabled = true;
            }
        }
    }
}
