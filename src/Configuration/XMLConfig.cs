﻿#region Usings

using System.Collections.Generic;
using System.IO;
using System.Xml;

#endregion

namespace IHI.Server.Configuration
{
    public class XmlConfig
    {
        private readonly XmlDocument _document;
        private readonly string _path;

        /// <summary>
        ///   True if the file required creating when constructing this object, false otherwise.
        /// </summary>
        internal bool WasCreated
        {
            get;
            private set;
        }

        /// <summary>
        ///   Loads an Xml config file into memory.
        /// </summary>
        /// <param name = "path">The path to the Xml config file.</param>
        internal XmlConfig(string path)
        {
            bool wasCreated;

            if (!EnsureFile(new FileInfo(path), out wasCreated))
            {
                CoreManager.ServerCore.StandardOut.Error("CONFIG",CoreManager.ServerCore.StringLocale.GetString("CORE:ERROR_CONFIG_CREATION_FAILED", path));
            }
            WasCreated = wasCreated;

            _document = new XmlDocument();

            try
            {
                _document.Load(path);
            }
            catch (XmlException)
            {
                _document.LoadXml(@"<?xml version='1.0' encoding='ISO-8859-1'?>\n<config>\n</config>");
                _document.Save(path);
            }

            _path = path;
        }

        /// <summary>
        ///   Save changes to the configuration file.
        /// </summary>
        internal void Save()
        {
            _document.Save(_path);
        }

        /// <summary>
        ///   Returns the internal XmlDocument object.
        ///   Not recommended for the inexperienced.
        /// </summary>
        internal XmlDocument GetInternalDocument()
        {
            return _document;
        }

        /// <summary>
        ///   Returns a value as a byte.
        /// </summary>
        /// <param name = "xPath">The XPath query.</param>
        /// <param name = "fallback">The value to return if the value is invalid.</param>
        internal byte ValueAsByte(string xPath, byte fallback)
        {
            byte result;

            try
            {
                if (!byte.TryParse(ValueAsString(xPath), out result))
                {
                    CoreManager.ServerCore.StandardOut.Error("Config", CoreManager.ServerCore.StringLocale.GetString("CORE:ERROR_CONFIG_INVALID_BYTE", xPath, fallback));
                    return fallback;
                }
            }
            catch
            {
                result = fallback;
            }
            return result;
        }

        /// <summary>
        ///   Returns a value as a signed byte.
        /// </summary>
        /// <param name = "xPath">The XPath query.</param>
        /// <param name = "fallback">The value to return if the value is invalid.</param>
        internal sbyte ValueAsSbyte(string xPath, sbyte fallback)
        {
            sbyte result;

            try
            {
                if (!sbyte.TryParse(ValueAsString(xPath), out result))
                {
                    CoreManager.ServerCore.StandardOut.Error("CONFIG", CoreManager.ServerCore.StringLocale.GetString("CORE:ERROR_CONFIG_INVALID_SBYTE", xPath, fallback));
                    return fallback;
                }
            }
            catch
            {
                result = fallback;
            }
            return result;
        }

        /// <summary>
        ///   Returns a value as a short.
        /// </summary>
        /// <param name = "xPath">The XPath query.</param>
        /// <param name = "fallback">The value to return if the value is invalid.</param>
        internal short ValueAsShort(string xPath, short fallback)
        {
            short result;

            try
            {
                if (!short.TryParse(ValueAsString(xPath), out result))
                {
                    CoreManager.ServerCore.StandardOut.Error("CONFIG", CoreManager.ServerCore.StringLocale.GetString("CORE:ERROR_CONFIG_INVALID_SHORT", xPath, fallback));
                    return fallback;
                }
            }
            catch
            {
                result = fallback;
            }
            return result;
        }

        /// <summary>
        ///   Returns a value as an unsigned short.
        /// </summary>
        /// <param name = "xPath">The XPath query.</param>
        /// <param name = "fallback">The value to return if the value is invalid.</param>
        internal ushort ValueAsUshort(string xPath, ushort fallback)
        {
            ushort result;

            try
            {
                if (!ushort.TryParse(ValueAsString(xPath), out result))
                {
                    CoreManager.ServerCore.StandardOut.Error("CONFIG", CoreManager.ServerCore.StringLocale.GetString("CORE:ERROR_CONFIG_INVALID_USHORT", xPath, fallback));
                    return fallback;
                }
            }
            catch
            {
                result = fallback;
            }
            return result;
        }

        /// <summary>
        ///   Returns a value as an int.
        /// </summary>
        /// <param name = "xPath">The XPath query.</param>
        /// <param name = "fallback">The value to return if the value is invalid.</param>
        internal int ValueAsInt(string xPath, int fallback)
        {
            int result;

            try
            {
                if (!int.TryParse(ValueAsString(xPath), out result))
                {
                    CoreManager.ServerCore.StandardOut.Error("CONFIG", CoreManager.ServerCore.StringLocale.GetString("CORE:ERROR_CONFIG_INVALID_INT", xPath, fallback));
                    return fallback;
                }
            }
            catch
            {
                result = fallback;
            }
            return result;
        }

        /// <summary>
        ///   Returns a value as an unsigned int.
        /// </summary>
        /// <param name = "xPath">The XPath query.</param>
        /// <param name = "fallback">The value to return if the value is invalid.</param>
        internal uint ValueAsUint(string xPath, uint fallback)
        {
            uint result;

            try
            {
                if (!uint.TryParse(ValueAsString(xPath), out result))
                {
                    CoreManager.ServerCore.StandardOut.Error("CONFIG", CoreManager.ServerCore.StringLocale.GetString("CORE:ERROR_CONFIG_INVALID_UINT", xPath, fallback));
                    return fallback;
                }
            }
            catch
            {
                result = fallback;
            }
            return result;
        }

        /// <summary>
        ///   Returns a value as a long.
        /// </summary>
        /// <param name = "xPath">The XPath query.</param>
        /// <param name = "fallback">The value to return if the value is invalid.</param>
        internal long ValueAsLong(string xPath, long fallback)
        {
            long result;

            try
            {
                if (!long.TryParse(ValueAsString(xPath), out result))
                {
                    CoreManager.ServerCore.StandardOut.Error("CONFIG", CoreManager.ServerCore.StringLocale.GetString("CORE:ERROR_CONFIG_INVALID_LONG", xPath, fallback));
                    return fallback;
                }
            }
            catch
            {
                result = fallback;
            }
            return result;
        }

        /// <summary>
        ///   Returns a value as an unsigned long.
        /// </summary>
        /// <param name = "xPath">The XPath query.</param>
        /// <param name = "fallback">The value to return if the value is invalid.</param>
        internal ulong ValueAsUlong(string xPath, ulong fallback)
        {
            ulong result;

            try
            {
                if (!ulong.TryParse(ValueAsString(xPath), out result))
                {
                    CoreManager.ServerCore.StandardOut.Error("CONFIG", CoreManager.ServerCore.StringLocale.GetString("CORE:ERROR_CONFIG_INVALID_ULONG", xPath, fallback));
                    return fallback;
                }
            }
            catch
            {
                result = fallback;
            }
            return result;
        }

        /// <summary>
        ///   Returns a value as a string.
        /// </summary>
        /// <param name = "xPath">The XPath query.</param>
        internal string ValueAsString(string xPath)
        {
            XmlNode node = _document.SelectSingleNode(xPath + "/text()");
            if (node == null)
                return "";
            return node.Value;
        }

        /// <summary>
        ///   Creates a file if it doesn't exist, creating all non-existing parent directories in the process.
        /// </summary>
        /// <param name = "file">The file to create.</param>
        /// <returns>True if the file was created, false otherwise.</returns>
        internal static bool EnsureFile(FileInfo file)
        {
            if (file.Exists) // Does the file already exist?
                return true; // Yes, nothing needed.
            if (EnsureDirectory(file.Directory)) // Ensure all parent directories exist.
            {
                file.Create().Close(); // All missing parent directories created, create the file.
                return true;
            }
            return false; // Something went wrong, return false.
        }

        /// <summary>
        ///   Creates a file if it doesn't exist, creating all non-existing parent directories in the process.
        /// </summary>
        /// <param name = "file">The file to create.</param>
        /// <param name = "created">If the file was created then this is set to true.</param>
        /// <returns>True if the file was created, false otherwise.</returns>
        internal static bool EnsureFile(FileInfo file, out bool created)
        {
            if (file.Exists) // Does the file already exist?
            {
                created = false;
                return true; // Yes, nothing needed.
            }
            if (EnsureDirectory(file.Directory)) // Ensure all parent directories exist.
            {
                file.Create().Close(); // All missing parent directories created, create the file.
                created = true;
                return true;
            }
            created = false;
            return false; // Something went wrong, return false.
        }

        /// <summary>
        ///   Creates a directory if it doesn't exist, creating all non-existing parent directories in the process.
        /// </summary>
        /// <param name = "directory">The directory to create.</param>
        /// <returns>True if the directory was created, false otherwise.</returns>
        internal static bool EnsureDirectory(DirectoryInfo directory)
        {
            if (directory.Exists) // Does the directory already exist?
                return true; // Yes, nothing needed.

            Stack<DirectoryInfo> missingParents = new Stack<DirectoryInfo>(new[] {null, directory});

            DirectoryInfo parent = directory.Parent;

            while (!parent.Exists) // While the next parent directory don't exist...
            {
                missingParents.Push(parent); // Push it onto the MissingParents stack.
                parent = parent.Parent; // Go to the next parent
            }

            parent = missingParents.Pop();

            while (missingParents.Count > 0) // While their are missing parent directories
            {
                parent.Create(); // Create the directory
                parent = missingParents.Pop(); // Go to the next.
            }

            return true;
        }
    }
}