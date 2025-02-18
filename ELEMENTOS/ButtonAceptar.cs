using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace ELEMENTOS
{
    public class ButtonAceptar : Button
    {
        public ButtonAceptar()
        {
            this.BackColor = Color.PaleVioletRed;
            this.ForeColor = Color.White;
            this.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.Size = new Size(100, 50);
            this.Text = "Aceptar";

            // Asociar el evento Click
            this.Click += ButtonAceptar_Click;
        }

        private void ButtonAceptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aceptado");
        }
    }

    public class ButtonPlay : Button
    {

        // Campos
        private int borderSize = 0;
        private int borderRadius = 40;
        private Color borderColor = Color.DarkRed;

        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                if (value <= this.Height)
                    borderRadius = value;
                else borderRadius = this.Height;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BackgroundColor
        {
            get
            {
                return this.BackColor;
            }
            set
            {
                this.BackColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public Color TextColor
        {
            get
            {
                return this.ForeColor;
            }
            set
            {
                this.ForeColor = value;
            }
        }

        // Constructor
        public ButtonPlay()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(40, 40);
            this.BackColor = Color.DarkRed;
            this.ForeColor = Color.White;
            this.TextColor = Color.DarkRed;
            this.Resize += new EventHandler(Button_Resize);
        }

        // Métodos
        private GraphicsPath getFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            // Evitar que el texto se dibuje
            TextRenderer.DrawText(pevent.Graphics, "", this.Font, this.ClientRectangle, this.ForeColor);
            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = getFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = getFigurePath(rectBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathSurface);
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    if (borderSize >= 1)
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                this.Region = new Region(rectSurface);
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
            // --- DIBUJAR EL ÍCONO DE PLAY ---
            using (SolidBrush brush = new SolidBrush(Color.White)) // Color del icono
            {
                Point[] playTriangle = {
            new Point(this.Width / 3, this.Height / 4),   // Punto superior
            new Point(this.Width / 3, this.Height - this.Height / 4), // Punto inferior
            new Point(this.Width - this.Width / 4, this.Height / 2)  // Punta derecha
        };

                pevent.Graphics.FillPolygon(brush, playTriangle);
            }

        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                BorderRadius = this.Height;
        }


    }

    public class ButtonCarpeta : Button
    {

        // Campos
        private int borderSize = 0;
        private int borderRadius = 40;
        private Color borderColor = Color.DarkRed;

        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                if (value <= this.Height)
                    borderRadius = value;
                else borderRadius = this.Height;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BackgroundColor
        {
            get
            {
                return this.BackColor;
            }
            set
            {
                this.BackColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public Color TextColor
        {
            get
            {
                return this.ForeColor;
            }
            set
            {
                this.ForeColor = value;
            }
        }

        // Constructor
        public ButtonCarpeta()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(40, 40);
            this.BackColor = Color.DarkRed;
            this.ForeColor = Color.White;
            this.TextColor = Color.DarkRed;
            this.Resize += new EventHandler(Button_Resize);
        }

        // Métodos
        private GraphicsPath getFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Evitar que el texto se dibuje
            TextRenderer.DrawText(pevent.Graphics, "", this.Font, this.ClientRectangle, this.ForeColor);

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = getFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = getFigurePath(rectBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathSurface);
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    if (borderSize >= 1)
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                this.Region = new Region(rectSurface);
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }

            // --- DIBUJAR EL ÍCONO DE CARPETA ---
            using (SolidBrush brush = new SolidBrush(Color.White)) // Color del icono
            {
                int w = this.Width;
                int h = this.Height;

                //tamaño del icono//
                int iconWidth = (int)(w * 0.4);
                int iconHeight = (int)(h * 0.35);

                // Espacio para centrar el icono dentro del botón
                int offsetX = (w - iconWidth) / 2;
                int offsetY = (h - iconHeight) / 2;

                // Base de la carpeta (rectángulo principal)
                Rectangle folderBase = new Rectangle(offsetX, offsetY + iconHeight / 6, iconWidth, iconHeight);
                pevent.Graphics.FillRectangle(brush, folderBase);

                // Pestaña de la carpeta (parte superior)
                int tabWidth = (int)(iconWidth * 0.6);
                int tabHeight = (int)(iconHeight * 0.3);
                Rectangle folderTab = new Rectangle(offsetX, offsetY, tabWidth, tabHeight);
                pevent.Graphics.FillRectangle(brush, folderTab);
            }
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                BorderRadius = this.Height;
        }


    }

    //-------------------------------------------------------------------------------------//

    public class ButtonCerrar : Button
    {

        // Campos
        private int borderSize = 0;
        private int borderRadius = 40;
        private Color borderColor = Color.DarkRed;

        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                if (value <= this.Height)
                    borderRadius = value;
                else borderRadius = this.Height;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BackgroundColor
        {
            get
            {
                return this.BackColor;
            }
            set
            {
                this.BackColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public Color TextColor
        {
            get
            {
                return this.ForeColor;
            }
            set
            {
                this.ForeColor = value;
            }
        }

        // Constructor
        public ButtonCerrar()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(40, 40);
            this.BackColor = Color.DarkRed;
            this.ForeColor = Color.White;
            this.TextColor = Color.DarkRed;
            this.Resize += new EventHandler(Button_Resize);
        }

        // Métodos
        private GraphicsPath getFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Evitar que el texto se dibuje
            TextRenderer.DrawText(pevent.Graphics, "", this.Font, this.ClientRectangle, this.ForeColor);

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = getFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = getFigurePath(rectBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathSurface);
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    if (borderSize >= 1)
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                this.Region = new Region(rectSurface);
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }

            // --- DIBUJAR EL ÍCONO DE CERRAR (X) ---
            using (SolidBrush brush = new SolidBrush(Color.White)) // Color del icono
            {
                int w = this.Width;
                int h = this.Height;

                // Tamaño del icono (40% del botón)
                int iconSize = (int)(Math.Min(w, h) * 0.4); // Mantener el tamaño del icono proporcional

                // Espacio para centrar la X dentro del botón
                int offsetX = (w - iconSize) / 2;
                int offsetY = (h - iconSize) / 2;

                // Líneas de la X
                using (Pen pen = new Pen(brush, 3)) // Grosor de la línea de la X
                {
                    // Dibujar la primera línea diagonal de la X
                    pevent.Graphics.DrawLine(pen, offsetX, offsetY, offsetX + iconSize, offsetY + iconSize);

                    // Dibujar la segunda línea diagonal de la X
                    pevent.Graphics.DrawLine(pen, offsetX, offsetY + iconSize, offsetX + iconSize, offsetY);
                }
            }
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                BorderRadius = this.Height;
        }


    }
    //-------------------------------------------------------------------------------------//

    public class ButtonFastForward : Button
    {

        // Campos
        private int borderSize = 0;
        private int borderRadius = 40;
        private Color borderColor = Color.DarkRed;


        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                if (value <= this.Height)
                    borderRadius = value;
                else borderRadius = this.Height;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BackgroundColor
        {
            get
            {
                return this.BackColor;
            }
            set
            {
                this.BackColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public Color TextColor
        {
            get
            {
                return this.ForeColor;
            }
            set
            {
                this.ForeColor = value;
            }
        }


        // Constructor
        public ButtonFastForward()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(40, 40);
            this.BackColor = Color.DarkRed;
            this.ForeColor = Color.White;
            this.TextColor = Color.DarkRed;
            this.Resize += new EventHandler(Button_Resize);
        }

        // Métodos
        private GraphicsPath getFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Evitar que el texto se dibuje
            TextRenderer.DrawText(pevent.Graphics, "", this.Font, this.ClientRectangle, this.ForeColor);

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = getFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = getFigurePath(rectBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathSurface);
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    if (borderSize >= 1)
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                this.Region = new Region(rectSurface);
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }

            // --- DIBUJAR EL ÍCONO DE FAST FORWARD ---
            using (SolidBrush brush = new SolidBrush(Color.White)) // Color del icono
            {
                int w = this.Width;
                int h = this.Height;

                // Tamaño del icono (40% del botón)
                int iconWidth = (int)(w * 0.2); // Ancho de las flechas
                int iconHeight = (int)(h * 0.3); // Altura de las flechas

                // Espacio para centrar el icono dentro del botón
                int offsetX = (w - iconWidth) / 2;
                int offsetY = (h - iconHeight) / 2;



                // Flechas de Fast Forward (triángulos)
                Point[] fastForwardArrow1 = {
                    new Point(offsetX, offsetY), // Puntero izquierdo
                    new Point(offsetX + iconWidth, offsetY + iconHeight / 2), // Puntero derecho (abajo)
                    new Point(offsetX, offsetY + iconHeight) // Puntero izquierdo (abajo)
                };

                Point[] fastForwardArrow2 = {
                    new Point(offsetX + iconWidth, offsetY), // Puntero izquierdo
                    new Point(offsetX + 2 * iconWidth, offsetY + iconHeight / 2), // Puntero derecho (abajo)
                    new Point(offsetX + iconWidth, offsetY + iconHeight) // Puntero izquierdo (abajo)
                };

                // Dibujar las dos flechas
                pevent.Graphics.FillPolygon(brush, fastForwardArrow1);
                pevent.Graphics.FillPolygon(brush, fastForwardArrow2);
            }
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                BorderRadius = this.Height;
        }


    }
    //--------------------------------------------------------------------------------//
    public class ButtonBefore : Button
    {

        // Campos
        private int borderSize = 0;
        private int borderRadius = 40;
        private Color borderColor = Color.DarkRed;
        private float rotationAngle = 0;  // Ángulo de rotación


        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                if (value <= this.Height)
                    borderRadius = value;
                else borderRadius = this.Height;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BackgroundColor
        {
            get
            {
                return this.BackColor;
            }
            set
            {
                this.BackColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public Color TextColor
        {
            get
            {
                return this.ForeColor;
            }
            set
            {
                this.ForeColor = value;
            }
        }

        // Propiedad para controlar el ángulo de rotación
        [Category("RJ Code Advance")]
        public float RotationAngle
        {
            get { return rotationAngle; }
            set { rotationAngle = value; this.Invalidate(); }
        }

        // Constructor
        public ButtonBefore()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(40, 40);
            this.BackColor = Color.DarkRed;
            this.ForeColor = Color.White;
            this.TextColor = Color.DarkRed;
            this.Resize += new EventHandler(Button_Resize);

        }

        // Métodos
        private GraphicsPath getFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Guardamos el estado del gráfico (antes de rotarlo)
            pevent.Graphics.Save();

            // Trasladamos al centro del botón
            pevent.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);

            // Aplicamos la rotación
            pevent.Graphics.RotateTransform(rotationAngle);

            // Volvemos a trasladar el gráfico para que dibuje el contenido en su posición original
            pevent.Graphics.TranslateTransform(-this.Width / 2, -this.Height / 2);
            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = getFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = getFigurePath(rectBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathSurface);
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    if (borderSize >= 1)
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                this.Region = new Region(rectSurface);
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }

            // --- DIBUJAR EL ÍCONO DE FAST FORWARD ---
            using (SolidBrush brush = new SolidBrush(Color.White)) // Color del icono
            {
                int w = this.Width;
                int h = this.Height;

                // Tamaño del icono (40% del botón)
                int iconWidth = (int)(w * 0.2); // Ancho de las flechas
                int iconHeight = (int)(h * 0.3); // Altura de las flechas

                // Espacio para centrar el icono dentro del botón
                int offsetX = (w - iconWidth) / 2;
                int offsetY = (h - iconHeight) / 2;



                // Flechas de Fast Forward (triángulos)
                Point[] fastForwardArrow1 = {
                    new Point(offsetX, offsetY), // Puntero izquierdo
                    new Point(offsetX + iconWidth, offsetY + iconHeight / 2), // Puntero derecho (abajo)
                    new Point(offsetX, offsetY + iconHeight) // Puntero izquierdo (abajo)
                };

                Point[] fastForwardArrow2 = {
                    new Point(offsetX + iconWidth, offsetY), // Puntero izquierdo
                    new Point(offsetX + 2 * iconWidth, offsetY + iconHeight / 2), // Puntero derecho (abajo)
                    new Point(offsetX + iconWidth, offsetY + iconHeight) // Puntero izquierdo (abajo)
                };

                // Dibujar las dos flechas
                pevent.Graphics.FillPolygon(brush, fastForwardArrow1);
                pevent.Graphics.FillPolygon(brush, fastForwardArrow2);
            }
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                BorderRadius = this.Height;
        }


    }

    public enum TextPosition
    {
        Left,
        Right,
        Center,
        Sliding,
        None
    }
   public class ProgressBarButton : ProgressBar
    {
        private Color channelColor = Color.LightSteelBlue;
        private Color sliderColor = Color.RoyalBlue;
        private Color foreBackColor = Color.RoyalBlue;
        private int channelHeight = 6;
        private int sliderHeight = 6;
        private TextPosition showValue = TextPosition.Right;
        private string symbolBefore = "";
        private string symbolAfter = "";
        private bool showMaximun = false;
        //-> Others
        private bool paintedBack = false;
        private bool stopPainting = false;


        public ProgressBarButton()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.ForeColor = Color.White;
        }
        [Category("RJ Code Advance")]
        public Color ChannelColor
        {
            get { return channelColor; }
            set
            {
                channelColor = value;
                this.Invalidate();
            }
        }
        [Category("RJ Code Advance")]
        public Color SliderColor
        {
            get { return sliderColor; }
            set
            {
                sliderColor = value;
                this.Invalidate();
            }
        }
        [Category("RJ Code Advance")]
        public Color ForeBackColor
        {
            get { return foreBackColor; }
            set
            {
                foreBackColor = value;
                this.Invalidate();
            }
        }
        [Category("RJ Code Advance")]
        public int ChannelHeight
        {
            get { return channelHeight; }
            set
            {
                channelHeight = value;
                this.Invalidate();
            }
        }
        [Category("RJ Code Advance")]
        public int SliderHeight
        {
            get { return sliderHeight; }
            set
            {
                sliderHeight = value;
                this.Invalidate();
            }
        }
        [Category("RJ Code Advance")]
        public TextPosition ShowValue
        {
            get { return showValue; }
            set
            {
                showValue = value;
                this.Invalidate();
            }
        }
        [Category("RJ Code Advance")]
        public string SymbolBefore
        {
            get { return symbolBefore; }
            set
            {
                symbolBefore = value;
                this.Invalidate();
            }
        }
        [Category("RJ Code Advance")]
        public string SymbolAfter
        {
            get { return symbolAfter; }
            set
            {
                symbolAfter = value;
                this.Invalidate();
            }
        }
        [Category("RJ Code Advance")]
        public bool ShowMaximun
        {
            get { return showMaximun; }
            set
            {
                showMaximun = value;
                this.Invalidate();
            }
        }
        [Category("RJ Code Advance")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
            }
        }
        [Category("RJ Code Advance")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (stopPainting == false)
            {
                if (paintedBack == false)
                {
                    //Fields
                    Graphics graph = pevent.Graphics;
                    Rectangle rectChannel = new Rectangle(0, 0, this.Width, ChannelHeight);
                    using (var brushChannel = new SolidBrush(channelColor))
                    {
                        if (channelHeight >= sliderHeight)
                            rectChannel.Y = this.Height - channelHeight;
                        else rectChannel.Y = this.Height - ((channelHeight + sliderHeight) / 2);
                        //Painting
                        graph.Clear(this.Parent.BackColor);//Surface
                        graph.FillRectangle(brushChannel, rectChannel);//Channel
                                                                       //Stop painting the back & Channel
                        if (this.DesignMode == false)
                            paintedBack = true;
                    }
                }
                //Reset painting the back & channel
                if (this.Value == this.Maximum || this.Value == this.Minimum)
                    paintedBack = false;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (stopPainting == false)
            {
                //Fields
                Graphics graph = e.Graphics;
                double scaleFactor = (((double)this.Value - this.Minimum) / ((double)this.Maximum - this.Minimum));
                int sliderWidth = (int)(this.Width * scaleFactor);
                Rectangle rectSlider = new Rectangle(0, 0, sliderWidth, sliderHeight);
                using (var brushSlider = new SolidBrush(sliderColor))
                {
                    if (sliderHeight >= channelHeight)
                        rectSlider.Y = this.Height - sliderHeight;
                    else rectSlider.Y = this.Height - ((sliderHeight + channelHeight) / 2);
                    //Painting
                    if (sliderWidth > 1) //Slider
                        graph.FillRectangle(brushSlider, rectSlider);
                    if (showValue != TextPosition.None) //Text
                        DrawValueText(graph, sliderWidth, rectSlider);
                }
            }
            if (this.Value == this.Maximum) stopPainting = true;//Stop painting
            else stopPainting = false; //Keep painting
        }
        private void DrawValueText(Graphics graph, int sliderWidth, Rectangle rectSlider)
        {
            //Fields
            string text = symbolBefore + this.Value.ToString() + symbolAfter;
            if (showMaximun) text = text + "/" + symbolBefore + this.Maximum.ToString() + symbolAfter;
            var textSize = TextRenderer.MeasureText(text, this.Font);
            var rectText = new Rectangle(0, 0, textSize.Width, textSize.Height + 2);
            using (var brushText = new SolidBrush(this.ForeColor))
            using (var brushTextBack = new SolidBrush(foreBackColor))
            using (var textFormat = new StringFormat())
            {
                switch (showValue)
                {
                    case TextPosition.Left:
                        rectText.X = 0;
                        textFormat.Alignment = StringAlignment.Near;
                        break;
                    case TextPosition.Right:
                        rectText.X = this.Width - textSize.Width;
                        textFormat.Alignment = StringAlignment.Far;
                        break;
                    case TextPosition.Center:
                        rectText.X = (this.Width - textSize.Width) / 2;
                        textFormat.Alignment = StringAlignment.Center;
                        break;
                    case TextPosition.Sliding:
                        rectText.X = sliderWidth - textSize.Width;
                        textFormat.Alignment = StringAlignment.Center;
                        //Clean previous text surface
                        using (var brushClear = new SolidBrush(this.Parent.BackColor))
                        {
                            var rect = rectSlider;
                            rect.Y = rectText.Y;
                            rect.Height = rectText.Height;
                            graph.FillRectangle(brushClear, rect);
                        }
                        break;
                }
                //Painting
                graph.FillRectangle(brushTextBack, rectText);
                graph.DrawString(text, this.Font, brushText, rectText, textFormat);
            }
        }
    }
}