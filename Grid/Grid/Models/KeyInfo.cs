using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grid483W.Models
{
    public class KeyInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string text { get; set; }
        public string rowcol { get; set; }
        public int d_row { get; set; }
        public int d_column { get; set; }
        public string imagepath { get; set; }

        public KeyInfo() { }
        public KeyInfo(string text, string rowcol, int d_row, int d_column, string imagepath)
        {
            this.text = text;
            this.rowcol = rowcol;
            this.d_row = d_row;
            this.d_column = d_column;
            this.imagepath = imagepath;
        }
    }
}
