using System;
using System.Collections.Generic;

namespace HtmlGenerator.StringGenerator
{    
    public static class StringGeneratorRegister
    {
        private static Dictionary<string, CustomStringGenerator> FListaGenerators;

        private static void CreateInternalData()
        {
            if(FListaGenerators == null)
            {
                FListaGenerators = new Dictionary<string, CustomStringGenerator>();
                GenerateData();
            }
        }

        private static void GenerateData()
        {
            FListaGenerators.Add("ButtonStringGenerator", new ButtonStringGenerator());
            FListaGenerators.Add("CheckBoxStringGenerator", new CheckBoxStringGenerator());
            FListaGenerators.Add("RadioButtonStringGenerator", new RadioButtonStringGenerator());
            FListaGenerators.Add("DivStringGenerator", new DivStringGenerator());
            FListaGenerators.Add("HyperLinkStringGenerator", new HyperLinkStringGenerator());
            FListaGenerators.Add("LabelStringGenerator", new LabelStringGenerator());
            FListaGenerators.Add("OptionStringGenerator", new OptionStringGenerator());
            FListaGenerators.Add("SelectStringGenerator", new SelectStringGenerator());
            FListaGenerators.Add("TableStringGenerator", new TableStringGenerator());
            FListaGenerators.Add("TableCellStringGenerator", new TableCellStringGenerator());
            FListaGenerators.Add("TableHeadStringGenerator", new TableHeadStringGenerator());
        }

        public static CustomStringGenerator GetRegisteredGeneratorForClass(string pName)
        {
            CreateInternalData();
            CustomStringGenerator lGenerator = null;
            FListaGenerators.TryGetValue(pName, out lGenerator);
            return lGenerator;
        }


    }
}
