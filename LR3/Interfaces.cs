using System;
using System.Collections.Generic;
using System.Text;

namespace LR3
{
    interface IPatient
    {
        void takePills();
        void workWithAnalyzes(int blood, int urine);
        void getInfo();
    }
}
