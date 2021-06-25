﻿// Last Testament of Wanderers 
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GUIVoid.Controls;
using GUIVoid.Controls.Elements;
using GUIVoid.GameObjects.Resources;

namespace GUIVoid.SandBox
{
    public abstract partial class SandBoxElement : GraphicElement
    {
        //-------------------------------------------------
        #region Constant's Region

        #endregion
        //-------------------------------------------------
        #region Properties Region
        /// <summary>
        /// The Woto Resources Manager of this Sandbox.
        /// NOTICE: the sandbox elements, should have 
        /// separate <see cref="WotoRes"/>, and will not 
        /// accept passed-by values of <see cref="IRes"/>.
        /// </summary>
        public override WotoRes MyRes { get; set; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public SandBoxElement() : base()
        {

        }
        #endregion
        //-------------------------------------------------
    }
}
