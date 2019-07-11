using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace queryRecord
{
    public class RecordRow : System.Windows.Forms.DataGridViewRow
    {
       
        public DataGridViewTextBoxCell numberCell;
        public DataGridViewCheckBoxCell selectedCell;
        public DataGridViewTextBoxCell callTypeCell;
        public DataGridViewTextBoxCell extCell;
        public DataGridViewTextBoxCell callerCell;
        public DataGridViewTextBoxCell calledCell;
        public DataGridViewTextBoxCell agentCell;
        public DataGridViewTextBoxCell startTimeCell;
        public DataGridViewTextBoxCell endTimeCell;
        public DataGridViewTextBoxCell tallTimeCell;
        public DataGridViewImageCell playCell;
        public DataGridViewImageCell downCell;
        public DataGridViewTextBoxCell callidCell;
        public DataGridViewTextBoxCell tsidCell;
        public RecordRow() {
            numberCell = new DataGridViewTextBoxCell();
            selectedCell = new DataGridViewCheckBoxCell();
            selectedCell.ReadOnly = false;
            callTypeCell=new DataGridViewTextBoxCell();
            extCell = new DataGridViewTextBoxCell();
            callerCell = new DataGridViewTextBoxCell();
            calledCell = new DataGridViewTextBoxCell();
            agentCell = new DataGridViewTextBoxCell();
            startTimeCell = new DataGridViewTextBoxCell();
            endTimeCell = new DataGridViewTextBoxCell();
            tallTimeCell = new DataGridViewTextBoxCell();
            playCell = new DataGridViewImageCell();
            downCell = new DataGridViewImageCell();
            callidCell = new DataGridViewTextBoxCell();
            tsidCell = new DataGridViewTextBoxCell();
            this.Cells.AddRange(new DataGridViewCell[]{
                numberCell,
               selectedCell,
               callTypeCell,
               extCell,
               callerCell,calledCell,
               agentCell,
               startTimeCell,endTimeCell,tallTimeCell,
               playCell,downCell,
               callidCell,tsidCell
            } );
        }
    }
}
