//------------------------------------------------------------------------------
// <copyright file="Angular2ToolboxWindow.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Angular2_Toolbox
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("75ba0c69-c15f-4b13-ab3a-b0ed9e42f1e1")]
    public class Angular2ToolboxWindow : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Angular2ToolboxWindow"/> class.
        /// </summary>
        public Angular2ToolboxWindow() : base(null)
        {
            this.Caption = "Angular2 Toolbox";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new Angular2ToolboxWindowControl();
        }
    }
}
