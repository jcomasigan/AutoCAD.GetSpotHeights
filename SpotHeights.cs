// (C) Copyright 2016 by Jericho Masigan
using System;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;

[assembly: CommandClass(typeof(GetSpotHeights.MyCommands))]

namespace GetSpotHeights
{
    public class MyCommands
    {
        [CommandMethod("GETSH", CommandFlags.Modal)]
        public void GetSpotHeight()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;           
            PromptEntityResult prmtEnt = ed.GetEntity("\n\nSelect a 3d polyline ");
            if (prmtEnt.Status == PromptStatus.OK)
            {
                ObjectId insertedBlockId;
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    DBObject obj = tr.GetObject(prmtEnt.ObjectId, OpenMode.ForRead);
                    Polyline3d polyline = obj as Polyline3d;
                    if (polyline != null)
                    {
                        foreach (ObjectId id in polyline)
                        {
                            PolylineVertex3d vertex = tr.GetObject(id, OpenMode.ForRead) as PolylineVertex3d;
                            BlockTable blockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                            if (blockTable.Has("HOBLEV1"))
                            {
                                BlockTableRecord blockTableRecord = blockTable["HOBLEV1"].GetObject(OpenMode.ForRead) as BlockTableRecord;
                                if (blockTable != null)
                                {
                                    using (BlockReference spotHeight = new BlockReference(vertex.Position, blockTableRecord.ObjectId))
                                    {
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
                            else
                            {
                                ed.WriteMessage("\n\n Block HOBLEV1 does not exist in the drawing.");
                            }
                        }
                        tr.Commit();
                    }
                }
            }

        }
    }
}
