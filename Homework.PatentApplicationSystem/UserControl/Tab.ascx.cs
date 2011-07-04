﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homework.PatentApplicationSystem.UserControl
{
    public partial class Tab : System.Web.UI.UserControl
    {
        public event EventHandler TabClick;
        private bool _selected;
        public bool Selected
        {
            get { return _selected;}
            set { _selected = value; }
        }
        private string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        private string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblTabControl.Text = Text;
            

        }
    }
}