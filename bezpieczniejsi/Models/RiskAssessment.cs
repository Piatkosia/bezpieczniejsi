using System;
using System.ComponentModel;

namespace bezpieczniejsi
{
    public class RiskAssessment<T> : BindingList<T>, IRiskAssessment where T : RiskAssessmentRowModel, new()

    {
        public RAHeader Header { get; set; } = new RAHeader();
        public string JobDescription { get; set; }

        public int PropNum = new T().PropNum;

        public virtual int GetChildID(object obj)
        {
            if (obj == null) throw new NullReferenceException("obj is null:(");
            if (obj is T) return IndexOf(obj as T);
            else throw new NotSupportedException("Ale użyj jakiejś konkretniejszej klasy");
        }


        protected override void InsertItem(int index, T item)
        {
            item.Parent = this;
            base.InsertItem(index, item);
        }
    }
}
