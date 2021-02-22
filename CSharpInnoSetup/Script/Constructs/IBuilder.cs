
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs
{
    /// <summary>
    /// Builds instances of object type <typeparamref name="TType"/>
    /// </summary>
    /// <typeparam name="TType">The type being build</typeparam>
    internal interface IBuilder<TType>
    {
        /// <summary>
        /// Builds an object instance
        /// </summary>
        /// <returns>The new object instance of type <typeparamref name="TType"/></returns>
        TType Build();
    }
}
