using System;
using System.Collections.Generic;

namespace HtmlGenerator.StringGenerator
{    
    public static class StringGeneratorRegister
    {
        private static Dictionary<string, CustomStringGenerator> FListaGenerators;

        public static CustomStringGenerator GetRegisteredGeneratorForClass(string pName)
        {
            CreateInternalData();
            CustomStringGenerator lGenerator = null;
            FListaGenerators.TryGetValue(pName, out lGenerator);
            return lGenerator;
        }

        private static void CreateInternalData()
        {
            if (FListaGenerators == null)
            {
                FListaGenerators = new Dictionary<string, CustomStringGenerator>();
                GenerateData();
            }
        }

        private static void GenerateData()
        {
            FListaGenerators.Add("Button", new ButtonStringGenerator());
            FListaGenerators.Add("CheckBox", new CheckBoxStringGenerator());
            FListaGenerators.Add("RadioButton", new RadioButtonStringGenerator());
            FListaGenerators.Add("Div", new DivStringGenerator());
            FListaGenerators.Add("HyperLink", new HyperLinkStringGenerator());
            FListaGenerators.Add("Label", new LabelStringGenerator());
            FListaGenerators.Add("Option", new OptionStringGenerator());
            FListaGenerators.Add("Select", new SelectStringGenerator());
            FListaGenerators.Add("Table", new TableStringGenerator());
            FListaGenerators.Add("TableHeadCell", new TableHeadCellStringGenerator());
            FListaGenerators.Add("TableBodyCell", new TableCellStringGenerator());
            FListaGenerators.Add("TableFooterCell", new TableCellStringGenerator());
            FListaGenerators.Add("TableFooterCell", new TableCellStringGenerator());


        }
    }
}
