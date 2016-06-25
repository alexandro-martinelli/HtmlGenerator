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
            //FListaGenerators.Add();
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
