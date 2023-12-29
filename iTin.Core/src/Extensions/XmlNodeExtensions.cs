
using System;
using System.Xml;

using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides extension methods for searching for a specified XML node within the current <see cref="XmlNode"/>.
/// </summary> 
public static class XmlNodeExtensions
{
    /// <summary>
    /// Finds the specified XML node with the given node name within the current <see cref="XmlNode"/>.
    /// </summary>
    /// <param name="node">The current <see cref="XmlNode"/> to search for the specified node.</param>
    /// <param name="nodeName">The name of the XML node to find.</param>
    /// <returns>
    /// The <see cref="XmlNode"/> with the specified node name if found; otherwise, <see langword="null"/>.
    /// </returns>
    /// <remarks>
    /// <para>
    /// This method searches for a node with the specified name within the current <see cref="XmlNode"/> and its descendants.<br/>
    /// If a matching node is found, it is returned; otherwise, <see langword="null"/> is returned.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the input <see cref="XmlNode"/> (<paramref name="node"/>) is <see langword="null"/>.</exception>
    public static XmlNode FindNode(this XmlNode node, string nodeName)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(XmlNodeExtensions).Assembly.GetName().Name}, v{typeof(XmlNodeExtensions).Assembly.GetName().Version}, Namespace: {typeof(XmlNodeExtensions).Namespace}, Class: {nameof(XmlNodeExtensions)}");
        Logger.Instance.Debug(" Finds specified node in NodeName into current node. If not found returns null (Nothing in Visual Basic).");
        Logger.Instance.Debug($" > Signature: ({typeof(XmlNode)}) FindNode(this {typeof(XmlNode)}, {typeof(string)})");
        Logger.Instance.Debug($"   > node: {node.Name}");
        Logger.Instance.Debug($"   > nodeName: {nodeName}");

        if (node.Name == nodeName)
        {
            Logger.Instance.Debug($" > Output: {node}");
            return node;
        }

        if (!node.HasChildNodes)
        {
            Logger.Instance.Debug(" > Output: null");
            return null;
        }

        node = node.FirstChild;
        while (node != null)
        {
            if (FindNode(node, nodeName) != null)
            {
                return FindNode(node, nodeName);
            }

            node = node.NextSibling;
        }

        Logger.Instance.Debug(" > Output: null");
        return null;
    }
}
