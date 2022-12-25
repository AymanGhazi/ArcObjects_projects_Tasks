﻿using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoDatabaseInventory
{
    //public sealed class ColorSelector : ComboBox
    //{
    //    public ColorSelector()
    //    {
    //        DrawMode = DrawMode.OwnerDrawFixed;
    //        DropDownStyle = ComboBoxStyle.DropDownList;
    //    }

    //    protected override void OnDrawItem(DrawItemEventArgs e)
    //    {
    //        e.DrawBackground();

    //        e.DrawFocusRectangle();

    //        if (e.Index >= 0 && e.Index < Items.Count)
    //        {
    //            DropDownItem item = (DropDownItem)Items[e.Index];

    //            e.Graphics.DrawImage(item.Image, e.Bounds.Left, e.Bounds.Top);

    //            e.Graphics.DrawString(item.Value, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + item.Image.Width, e.Bounds.Top + 2);
    //        }

    //        base.OnDrawItem(e);
    //    }
    //} 
    public sealed class FieldsList
    {
        public IFeatureClass FeatureClassID { get; set; }

        public List<IField> fieldsSelected { get; set; }

    }

}
