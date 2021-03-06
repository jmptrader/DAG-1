﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DAG;

namespace DAG.Repositories
{
    public class InterfacesRepositoriesCodeGenerator : BaseClassesFromModelsCodeGenerator
    {

        public InterfacesRepositoriesCodeGenerator(string commandsNamespace, string generateClassesNamespace,
            string classDirectoryPath, bool update, string assemblyPath, string usingNamespaces) 
            : base(commandsNamespace, generateClassesNamespace, classDirectoryPath, update,
                assemblyPath, usingNamespaces, Path.Combine("Repositories", "Templates", "RepositoryInterfaceTemplate.txt"), "I{0}Repository")
        {
        }

        protected override void CreateBaseMarker()
            => new MarkerRepositoryCodeGenerator(_classDirectoryPath, _generateClassesNamespace, _update, _assemblyPath)
                .Generate();


        private class MarkerRepositoryCodeGenerator : BaseClassCodeGenerator
        {
            public MarkerRepositoryCodeGenerator(string classPath, string @namespace, bool update,
                string assemblyPath = "")
                : base(Path.Combine(classPath, "IRepository"), @namespace,
                    Path.Combine("Repositories", "Templates", "RepositoryMarkerInterfaceTemplate.txt"), update,
                    assemblyPath)
            {
            }
        }
    }
}
