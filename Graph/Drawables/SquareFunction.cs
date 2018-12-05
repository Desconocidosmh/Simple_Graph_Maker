﻿using System;
using System.Collections.Generic;
using Graph.MathUtils;
using Graph.System;
using SFML.System;
using SFML.Graphics;

namespace Graph.Drawables
{
    public class SquareFunction : Element, Drawable, ICalculate 
    {
        #region Properties

        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }

        public float Delta => (float)Math.Pow(B, 2) - 4 * A * C;

        #endregion

        #region Constructors

        public SquareFunction(float a, float b, float c)
        {
            A = a;
            B = b;
            C = c;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculate Y from X
        /// </summary>
        /// <param name="x">X parameter to calculate Y</param>
        /// <returns>Value of Y</returns>
        public float Calculate(float x) =>
                A * (float)Math.Pow(x, 2) + B * x + C;

        public override void Draw(RenderTarget target, RenderStates states)
        {
            var vertexes = new List<Vertex>();

            uint xPixels = GetParentWindow().Resolution.X;

            for (uint i = 0; i < xPixels; i++)
            {
                float xPos = Interpolation.Map(
                    i, 0, xPixels, -GetParentWindow().CoordinateSystem.Scale, GetParentWindow().CoordinateSystem.Scale);

                vertexes.Add(new Vertex(
                    GetParentWindow().ToWindowCoords(
                        new Vector2f(xPos, Calculate(xPos))), Color));
            }

            target.Draw(vertexes.ToArray(), PrimitiveType.LinesStrip);
        }

        #endregion
    }
}