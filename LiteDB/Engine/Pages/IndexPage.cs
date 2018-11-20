﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using static LiteDB.Constants;

namespace LiteDB.Engine
{
    /// <summary>
    /// The IndexPage thats stores object data.
    /// </summary>
    internal class IndexPage : BasePage
    {
        public IndexPage(PageBuffer buffer)
            : base(buffer)
        {
            ENSURE(this.PageType == PageType.Index);
        }

        public IndexPage(PageBuffer buffer, uint pageID)
            : base(buffer, pageID, PageType.Index)
        {
        }

        /// <summary>
        /// Read single IndexNode
        /// </summary>
        public IndexNode ReadNode(byte index)
        {
            var segment = base.Get(index);

            return new IndexNode(this, segment);
        }

        /// <summary>
        /// Insert new IndexNode. After call this, "node" instance can't be changed
        /// </summary>
        public IndexNode InsertNode(byte level, BsonValue key, PageAddress dataBlock)
        {
            var segment = base.Insert(IndexNode.GetNodeLength(level, key));

            return new IndexNode(this, segment, level, key, dataBlock);
        }

        /// <summary>
        /// Delete index node based on page index
        /// </summary>
        public void DeleteNode(byte index)
        {
            base.Delete(index);
        }
    }
}