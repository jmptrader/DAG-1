﻿using System;
using System.IO;

namespace DomainDrivenDesignApiCodeGenerator
{
    public abstract class BaseClassCodeGenerator : BaseCodeGenerator
    {
        protected readonly string _classPath;
        protected readonly string _namespace;
        protected readonly string _template;
        protected readonly bool _update;

        protected BaseClassCodeGenerator(string classPath, string @namespace, string template, bool update, string assemblyPath = "") : base(assemblyPath)
        {
            _classPath = classPath;
            _namespace = @namespace;
            _template = template;
            _update = update;
        }

        public override void Generate()
        {

            var template = File.ReadAllText(_template);
            var body = template.Replace(Consts.Namespace, _namespace);
            File.WriteAllText(_classPath, body);

            Console.WriteLine($"{_classPath} created");
        }
    }
}