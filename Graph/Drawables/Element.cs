﻿using SFML.Graphics;
using Graph.System;

namespace Graph.Drawables
{
    public abstract class Element : ICalculate
    {
        public virtual Color Color { get; set; } = Color.Black;

        /// <summary>
        /// Calculate value of Y from X
        /// </summary>
        /// <param name="x">X parameter to calculate Y</param>
        /// <returns>Value of Y</returns>
        public abstract float Calculate(float x);
    }
}