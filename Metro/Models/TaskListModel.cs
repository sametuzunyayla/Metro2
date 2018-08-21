using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metro.Models
{
    public class TaskListModel
    {
        public int GorevId { get; set; }
        public string Gorev_Adı { get; set; }
        public string Aciklamasi { get; set; }
        public string KategoriAdi { get; set; }
        public string IsOnceligi { get; set; }
        public string Yonetici { get; set; }
        public string Gorevli { get; set; }
    }
}