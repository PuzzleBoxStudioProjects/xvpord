namespace CorruptedSmileStudio.Utils
{
    /// <summary>
    /// A simple XML reader.
    /// </summary>
    public class TinyXmlReader
    {
        /// <summary>
        /// The XML string being parsed.
        /// </summary>
        public string xmlString = "";
        /// <summary>
        /// The current index within the string.
        /// </summary>
        public int index = 0;
        /// <summary>
        /// Initialise class.
        /// </summary>
        /// <param name="newXmlString">The XML to parse.</param>
        public TinyXmlReader(string newXmlString)
        {
            xmlString = newXmlString;
        }

        /// <summary>
        /// The current tagName
        /// </summary>
        public string tagName = "";
        /// <summary>
        /// Whether the current tag is an opening or closing tag
        /// </summary>
        public bool isOpeningTag = false;
        /// <summary>
        /// The current contents of the tag.
        /// </summary>
        public string content = "";

        int IndexOf(char character, int startPosition)
        {
            int i = startPosition;
            while (i < xmlString.Length)
            {
                if (xmlString[i] == character)
                    return i;
                ++i;
            }
            return -1;
        }
        /// <summary>
        /// Read entire XML document
        /// </summary>
        /// <returns>True while reading and false when EOF</returns>
        public bool Read()
        {
            if (index > -1)
                index = xmlString.IndexOf("<", index);

            if (index == -1)
            {
                return false;
            }
            ++index;

            int endOfTag = IndexOf('>', index);
            int endOfName = endOfTag;
            if ((endOfName == -1) || (endOfTag < endOfName))
            {
                endOfName = endOfTag;
            }

            if (endOfTag == -1)
            {
                return false;
            }

            tagName = xmlString.Substring(index, endOfName - index);

            index = endOfTag;

            if (tagName.StartsWith("/"))
            {
                isOpeningTag = false;
                tagName = tagName.Remove(0, 1); // remove the slash
            }
            else
            {
                isOpeningTag = true;
            }

            // if an opening tag, get the content
            if (isOpeningTag)
            {
                int startOfCloseTag = xmlString.IndexOf("<", index);
                if (startOfCloseTag == -1)
                {
                    return false;
                }

                content = xmlString.Substring(index + 1, startOfCloseTag - index - 1);
                content = content.Trim();
            }

            return true;
        }
        /// <summary>
        /// Read a tag until it reaches the end tag.
        /// </summary>
        /// <param name="endingTag">The tag to read</param>
        /// <returns>True while reading tag, false when done.</returns>
        public bool Read(string endingTag)
        {
            bool retVal = Read();
            if (tagName == endingTag && !isOpeningTag)
            {
                retVal = false;
            }
            return retVal;
        }
    }
}