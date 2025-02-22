﻿using org.pdfclown.documents.contents.composition;
using System;
using System.Drawing;
using System.Text;

namespace DanfeSharp
{
    internal static class Extentions
    {
        private const float PointFactor = 72F / 25.4F;

        /// <summary>
        /// Converts Millimeters to Point
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public static float ToPoint(this float mm)
        {
            return PointFactor * mm;
        }

        /// <summary>
        /// Converts Point to Millimeters
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static float ToMm(this float point)
        {
            return point / PointFactor;
        }

        /// <summary>
        /// Converts Point to Millimeters
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static SizeF ToMm(this SizeF s)
        {
            return new SizeF(s.Width.ToMm(), s.Height.ToMm());
        }

        /// <summary>
        /// Converts Point to Millimeters
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static SizeF ToPointMeasure(this SizeF s)
        {
            return new SizeF(s.Width.ToPoint(), s.Height.ToPoint());
        }

        /// <summary>
        /// Converts Millimeters to Point
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public static double ToPoint(this double mm)
        {
            return PointFactor * mm;
        }

        /// <summary>
        /// Converts Point to Millimeters
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static double ToMm(this double point)
        {
            return point / PointFactor;
        }

        public static RectangleF InflatedRetangle(this RectangleF rect, float top, float button, float horizontal)
        {
            return new RectangleF(rect.X + horizontal, rect.Y + top, rect.Width - 2 * horizontal, rect.Height - top - button);
        }

        public static RectangleF InflatedRetangle(this RectangleF rect, float value) => rect.InflatedRetangle(value, value, value);

        public static RectangleF ToPointMeasure(this RectangleF r) => new RectangleF(r.X.ToPoint(), r.Y.ToPoint(), r.Width.ToPoint(), r.Height.ToPoint());

        public static RectangleF CutTop(this RectangleF r, float height) => new RectangleF(r.X, r.Y + height, r.Width, r.Height - height);
        public static RectangleF CutBottom(this RectangleF r, float height) => new RectangleF(r.X, r.Y, r.Width, r.Height - height);
        public static RectangleF CutLeft(this RectangleF r, float width) => new RectangleF(r.X + width, r.Y, r.Width - width, r.Height);

        public static PointF ToPointMeasure(this PointF r) => new PointF(r.X.ToPoint(), r.Y.ToPoint());
        
        public static StringBuilder AppendChaveValor(this StringBuilder sb, String chave, String valor)
        {
            if (sb.Length > 0) sb.Append(' ');
            return sb.Append(chave).Append(": ").Append(valor);
        }

        public static XAlignmentEnum ToPdfClownAlignment(this HorizontalAlignment ah)
        {
            switch (ah)
            {
                case HorizontalAlignment.Left:
                    return XAlignmentEnum.Left;
                case HorizontalAlignment.Center:
                    return XAlignmentEnum.Center;
                case HorizontalAlignment.Right:
                    return XAlignmentEnum.Right;
            }

            throw new InvalidOperationException();
        }

        public static YAlignmentEnum ToPdfClownAlignment(this VerticalAlignment av)
        {
            switch (av)
            {
                case VerticalAlignment.Top:
                    return YAlignmentEnum.Top;
                case VerticalAlignment.Center:
                    return YAlignmentEnum.Middle;
                case VerticalAlignment.Bottom:
                    return YAlignmentEnum.Bottom;
            }

            throw new InvalidOperationException();
        }



    }
}
