﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 11.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace ProxyApi.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "11.0.0.0")]
    public partial class ProxyTemplate : ProxyTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"
(function($) {
	""use strict"";

	if (!$) {
		throw ""jQuery is required"";
	}

	$.proxies = $.proxies || {};

	function getQueryString(params, queryString) {
		queryString = queryString || """";
		for(var prop in params) {
			if (params.hasOwnProperty(prop)) {
				var val = getArgValue(params[prop]);
				if (val === null) continue;

				if ("""" + val === ""[object Object]"") {
					queryString = getQueryString(params[prop], queryString);
					continue;
				}

				if (queryString.length) {
					queryString += ""&"";
				} else {
					queryString += ""?"";
				}
				queryString = queryString + prop + ""="" +val;
			}
		}
		return queryString;
	}

	function getArgValue(val) {
		if (val === undefined || val === null) return null;
		return val;
	}

	function invoke(url, type, urlParams, body) {
		url += getQueryString(urlParams);


		var ajaxOptions = $.extend({}, this.defaultOptions, {
			url: url,
			type: type
		});

		if (body) {
			ajaxOptions.data = body;
		}

		if (this.antiForgeryToken) {
			var token = $.isFunction(this.antiForgeryToken) ? this.antiForgeryToken() : this.antiForgeryToken;
			if (token) {
				ajaxOptions.headers = ajaxOptions.headers || {};
				ajaxOptions.headers[""");
            
            #line 61 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ValidateHttpAntiForgeryTokenAttribute.RequestVerificationTokenHeader));
            
            #line default
            #line hidden
            this.Write("\"] = token\r\n\t\t\t}\r\n\t\t}\r\n\t\r\n\t\treturn $.ajax(ajaxOptions);\r\n\t};\r\n\r\n\tfunction default" +
                    "AntiForgeryTokenAccessor() {\r\n\t\treturn $(\"input[name=__RequestVerificationToken]" +
                    "\").val();\r\n\t};\r\n\r\n\t/* Proxies */\r\n\r\n\t");
            
            #line 74 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
 foreach(var definition in this.Definitions) { 
            
            #line default
            #line hidden
            this.Write("\t$.proxies.");
            
            #line 75 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(definition.Name));
            
            #line default
            #line hidden
            this.Write(" = {\r\n\t\tdefaultOptions: {},\r\n\t\tantiForgeryToken: defaultAntiForgeryTokenAccessor," +
                    "\r\n");
            
            #line 78 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
 foreach(var method in definition.ActionMethods) { 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 80 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"

	var allParameters = method.UrlParameters.AsEnumerable();
	
	if (method.BodyParameter != null) {
		allParameters = allParameters.Concat(new [] { method.BodyParameter });
	}
	var parameterList = string.Join(",", allParameters.Where(m => m != null).OrderBy(m => m.Index).Select(m => m.Name).ToArray());

            
            #line default
            #line hidden
            this.Write("\t");
            
            #line 88 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(method.Name));
            
            #line default
            #line hidden
            this.Write(": function(");
            
            #line 88 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(parameterList));
            
            #line default
            #line hidden
            this.Write(") {\r\n\t\treturn invoke.call(this, \"");
            
            #line 89 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(method.Url));
            
            #line default
            #line hidden
            this.Write("\", \"");
            
            #line 89 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(method.Type.ToString().ToLower()));
            
            #line default
            #line hidden
            this.Write("\", \r\n\t\t");
            
            #line 90 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
 if (method.UrlParameters.Any()) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t{\r\n\t\t\t");
            
            #line 92 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
 
			var p = new List<string>();
			foreach (var parameter in method.UrlParameters) { 
				p.Add(string.Format("{0}: arguments[{1}]", parameter.Name, parameter.Index));
			}
			
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 98 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Join(",", p)));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t}\r\n\t\t");
            
            #line 100 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("\t\t\t{}\r\n\t\t");
            
            #line 102 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t");
            
            #line 103 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
 if (method.BodyParameter != null) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t, arguments[");
            
            #line 104 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(method.BodyParameter.Index));
            
            #line default
            #line hidden
            this.Write("]);\r\n\t\t");
            
            #line 105 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("\t\t\t);\r\n\t\t");
            
            #line 107 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t},\r\n");
            
            #line 109 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("};\r\n\t");
            
            #line 111 "C:\Users\dramirez\Documents\GitHub\ProxyApi\ProxyApi\Templates\ProxyTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("}(jQuery));");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "11.0.0.0")]
    public class ProxyTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
