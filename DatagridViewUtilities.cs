using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcode
{
    public class DatagridViewUtilities
    {
        /// <summary>
        /// DataGridView properties tat contain numbers (format -> 0.00)
        /// </summary>
        /// <param name="g"></param>
        public void GridProp(DataGridView g)
        {
            g.RowHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            g.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            g.EnableHeadersVisualStyles = false;
            g.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            g.DefaultCellStyle.Format = "N2";
            g.GridColor = SystemColors.ControlLight;

            foreach (DataGridViewColumn column in g.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // double buffering for datagridview - (if rendering is slow))
            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                Type dgvType = g.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(g, true, null);
            }

        }


        /// <summary>
        /// Method that checks the decimal separator 
        /// </summary>
        /// <param name="g"></param>
        public void CheckDecimalSeparator_Grid(DataGridView g)
        {
            if (g[g.CurrentCell.ColumnIndex, g.CurrentCell.RowIndex].GetType() == typeof(DataGridViewTextBoxCell))
            {
                if (g[g.CurrentCell.ColumnIndex, g.CurrentCell.RowIndex].Value != null)
                {
                    string val = ReplaceSeparator(Convert.ToString(g[g.CurrentCell.ColumnIndex, g.CurrentCell.RowIndex].Value));

                    float risultato;
                    bool controllo = Single.TryParse(val, out risultato);

                    if (controllo == false)
                    {
                        g[g.CurrentCell.ColumnIndex, g.CurrentCell.RowIndex].Value = "";
                    }
                    else
                    {
                        g[g.CurrentCell.ColumnIndex, g.CurrentCell.RowIndex].Value = val;
                    }
                }

            }
        }



        /// <summary>
        /// Method that indicates whether the decimal separator is a comma or a point
        /// </summary>
        /// <returns>returns true if the separator is a point, or false if the separator is a comma </returns>
        public bool CheckDecimalSeparator()
        {
            bool Punto = false; // Separatore = , (virgola)

            char a = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (a.ToString() == ".")
            {
                Punto = true; // Separatore = . (punto)
            }

            return Punto;
        }


        /// <summary>
        /// Method that takes a string as input and replaces the point with a comma or vice versa depending on the decimal separator set in the pc 
        /// </summary>
        /// <param name="val"></param>
        /// <returns>returns the same string entered but with the correct decimal separator </returns>
        public string ReplaceSeparator(string val)
        {
            if (CheckDecimalSeparator() == true)
            {
                val = val.Replace(",", ".");
            }
            else
            {
                val = val.Replace(".", ",");
            }

            return val;
        }

    }

}