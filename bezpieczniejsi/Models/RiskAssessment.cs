﻿using System;
using System.ComponentModel;

namespace bezpieczniejsi
{
    public class RiskAssessment<T> : BindingList<T>, IRiskAssessment where T : RiskAssessmentRowModel, new()

    {
    public RAHeader Header { get; set; } = new RAHeader();

        public virtual int GetChildID(object obj)
        {
            throw new NotSupportedException("Ale użyj jakiejś konkretniejszej klasy");
        }

        protected override void InsertItem(int index, T item)
        {
            item.Parent = this;
            base.InsertItem(index, item);
        }
    }
}
