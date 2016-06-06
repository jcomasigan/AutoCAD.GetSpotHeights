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
                GetSpotHeightForm shForm = new GetSpotHeightForm(prmtEnt);
                shForm.ShowDialog();
            }

        }
    }
}
