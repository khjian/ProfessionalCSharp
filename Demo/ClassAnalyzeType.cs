using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public class ClassAnalyzeType
    {
        static StringBuilder OutputText = new StringBuilder();

        public static void AnalyzeType(Type t)
        {
            AddToOutput("Type Name:" + t.Name);
            AddToOutput("Full Name:" + t.FullName);
            AddToOutput("Namespace:" + t.Namespace);

            Type tBase = t.BaseType;
            if (tBase != null)
            {
                AddToOutput("Base Type:" + tBase.Name);
            }

            Type tUnderlyingSystem = t.UnderlyingSystemType;
            AddToOutput("UnderlyingSystem:" + tUnderlyingSystem);
            AddToOutput("\nPUBLIC MEMBERS:");
            MemberInfo[] members = t.GetMembers();
            foreach (var memberInfo in members)
            {
                AddToOutput(memberInfo.DeclaringType + " " + memberInfo.MemberType + " " + memberInfo.Name);
            }
            MessageBox.Show(OutputText.ToString(), "Analysis of type " + t.Name);
        }

        static void AddToOutput(string Text)
        {
            OutputText.Append("\n" + Text);
        }
    }
}
