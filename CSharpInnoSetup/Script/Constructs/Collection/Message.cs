
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_messagessection.htm">Documentation</a>, or
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_custommessagessection.htm">Documentation</a>
    /// </summary>
    public sealed class Message
    {
        /// <summary>
        /// Initializes a new <see cref="Message"/>
        /// </summary>
        /// <param name="text"><see cref="Text"/></param>
        /// <param name="qualifier"><see cref="Qualifier"/></param>
        public Message(string text, Expression<Func<Language>> qualifier = null)
        {
            Text = text;

            if(qualifier != null)
            {
                Qualifier = ((PropertyInfo)((MemberExpression)qualifier.Body).Member).Name;
            }
        }

        /// <summary>
        /// The message text
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// The language qualifier, or null if not language specific
        /// </summary>
        public string Qualifier { get; private set; }
    }
}
