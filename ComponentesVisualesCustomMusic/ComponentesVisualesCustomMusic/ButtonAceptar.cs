using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using Image = System.Drawing.Image;

namespace ComponentesVisualesCustomMusic
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
            this.Click += ButtonAceptar_Click;
        }

        private void ButtonAceptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aceptado");
        }
    }
    //-------------------------------------------------------------------------//
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


            //hacerlo redondo//
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
    //----------------------------------------------------------------------------------------//
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

            //para hacer el boton redondo//
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


        //metodo para que cuando hagas click te abra el explorador de archivos//
        private void CarpetaButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

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


        //para que cambie cada vex que el boton cambia)
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
            this.Click += CloseButton_Click;
        }

        //metodo que nos va a poner por defecto que cuando hagamos click en este boton nos cierra la app//
        private void CloseButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
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

            //hacer el boton redondo//
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

        //se nos rehace cuando cambia de tamaño//
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
            this.Resize += new EventHandler(Button_Resize);
            this.TextColor = this.BackColor;
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
            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);


            // Evitar que el texto se dibuje
            TextRenderer.DrawText(pevent.Graphics, "", this.Font, this.ClientRectangle, this.ForeColor);


            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);


            //hacemos redondo el boton//
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

            // --- DIBUJAR EL ÍCONO DE FAST FORWARD (>> CENTRADO) ---
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                int w = this.Width;
                int h = this.Height;
                int iconWidth = (int)(w * 0.2);
                int iconHeight = (int)(h * 0.3);
                int centerX = w / 2;
                int centerY = h / 2;
                int spacing = iconWidth / 3;

                // Flechas de Fast Forward (>>)
                Point[] fastForwardArrow1 = {
                new Point(centerX - iconWidth + spacing, centerY - iconHeight / 2),
                new Point(centerX + spacing, centerY),
                new Point(centerX - iconWidth + spacing, centerY + iconHeight / 2)
            };
                Point[] fastForwardArrow2 = {
                new Point(centerX + spacing, centerY - iconHeight / 2),
                new Point(centerX + iconWidth + spacing, centerY),
                new Point(centerX + spacing, centerY + iconHeight / 2)
            };

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

        //para que se nos reaga cada vez que se cambia el tamaño//
        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                BorderRadius = this.Height;
        }


    }
    //--------------------------------------------------------------------------------//
    public class ButtonBefore : Button
    {
        //campos//
        private int borderSize = 0;
        private int borderRadius = 40;
        private Color borderColor = Color.DarkRed;
        private float rotationAngle = 0;


        //propiedades//
        [Category("RJ Code Advance")]
        public int BorderSize { get => borderSize; set { borderSize = value; this.Invalidate(); } }
        [Category("RJ Code Advance")]
        public int BorderRadius { get => borderRadius; set { borderRadius = (value <= this.Height) ? value : this.Height; this.Invalidate(); } }
        [Category("RJ Code Advance")]
        public Color BorderColor { get => borderColor; set { borderColor = value; this.Invalidate(); } }
        [Category("RJ Code Advance")]
        public Color BackgroundColor { get => this.BackColor; set { this.BackColor = value; } }
        [Category("RJ Code Advance")]
        public Color TextColor { get => this.ForeColor; set { this.ForeColor = value; } }
        [Category("RJ Code Advance")]
        public float RotationAngle { get => rotationAngle; set { rotationAngle = value; this.Invalidate(); } }

        public ButtonBefore()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(40, 40);
            this.BackColor = Color.DarkRed;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Button_Resize);
            this.TextColor = this.BackColor;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Save();
            pevent.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            pevent.Graphics.RotateTransform(rotationAngle);
            pevent.Graphics.TranslateTransform(-this.Width / 2, -this.Height / 2);
            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);


            //lo hacemos redondo//
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

            // --- DIBUJAR EL ÍCONO DE PREVIOUS SONG (<<) ---
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                int w = this.Width;
                int h = this.Height;
                int iconWidth = (int)(w * 0.2);
                int iconHeight = (int)(h * 0.3);
                int centerX = w / 2;
                int centerY = h / 2;
                int spacing = iconWidth / 3;

                // Flechas de Previous (<<)
                Point[] previousArrow1 = {
                  new Point(centerX - spacing, centerY - iconHeight / 2),
                  new Point(centerX - iconWidth - spacing, centerY),
                  new Point(centerX - spacing, centerY + iconHeight / 2)
              };
                Point[] previousArrow2 = {
                  new Point(centerX + iconWidth - spacing, centerY - iconHeight / 2),
                  new Point(centerX - spacing, centerY),
                  new Point(centerX + iconWidth - spacing, centerY + iconHeight / 2)
              };

                pevent.Graphics.FillPolygon(brush, previousArrow1);
                pevent.Graphics.FillPolygon(brush, previousArrow2);
            }
        }

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

        //si cambias el tamaño este metodo te lo rehace//
        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                BorderRadius = this.Height;
        }
    }

    //--------------------------------------------------------------------------------------------------------//
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
        //campos por defecto//
        private Color channelColor = Color.PaleVioletRed;
        private Color sliderColor = Color.MediumVioletRed;
        private Color foreBackColor = Color.PaleVioletRed;
        private int channelHeight = 6;
        private int sliderHeight = 6;
        private TextPosition showValue = TextPosition.Right;
        private string symbolBefore = "";
        private string symbolAfter = "";
        private bool showMaximun = false;
        private bool paintedBack = false;
        private bool stopPainting = false;


        public ProgressBarButton()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.ForeColor = Color.White;
            this.channelColor = Color.DarkRed;
            this.foreBackColor = Color.DarkRed;
            this.Value = 50;

        }

        //propiedades custom//
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

        //
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (stopPainting == false)
            {
                if (paintedBack == false)
                {
                    
                    Graphics graph = pevent.Graphics;
                    Rectangle rectChannel = new Rectangle(0, 0, this.Width, ChannelHeight);
                    using (var brushChannel = new SolidBrush(channelColor))
                    {
                        if (channelHeight >= sliderHeight)
                            rectChannel.Y = this.Height - channelHeight;
                        else rectChannel.Y = this.Height - ((channelHeight + sliderHeight) / 2);
                        
                        graph.Clear(this.Parent.BackColor);
                        graph.FillRectangle(brushChannel, rectChannel); 
                        if (this.DesignMode == false)
                            paintedBack = true;
                    }
                }
                
                if (this.Value == this.Maximum || this.Value == this.Minimum)
                    paintedBack = false;
            }
        }

        

        protected override void OnPaint(PaintEventArgs e)
        {
            if (stopPainting == false)
            {
                
                Graphics graph = e.Graphics;
                double scaleFactor = (((double)this.Value - this.Minimum) / ((double)this.Maximum - this.Minimum));
                int sliderWidth = (int)(this.Width * scaleFactor);
                Rectangle rectSlider = new Rectangle(0, 0, sliderWidth, sliderHeight);
                using (var brushSlider = new SolidBrush(sliderColor))
                {
                    if (sliderHeight >= channelHeight)
                        rectSlider.Y = this.Height - sliderHeight;
                    else rectSlider.Y = this.Height - ((sliderHeight + channelHeight) / 2);
                    
                    if (sliderWidth > 1) 
                        graph.FillRectangle(brushSlider, rectSlider);
                    if (showValue != TextPosition.None) 
                        DrawValueText(graph, sliderWidth, rectSlider);
                }
            }
            if (this.Value == this.Maximum) stopPainting = true;
            else stopPainting = false; 
        }
        private void DrawValueText(Graphics graph, int sliderWidth, Rectangle rectSlider)
        {
            
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
                
                graph.FillRectangle(brushTextBack, rectText);
                graph.DrawString(text, this.Font, brushText, rectText, textFormat);
            }
        }
    }
    //----------------------------------------------------------------------------------------------------------------------//
    public class PanelFondo : Panel
    {

        public PanelFondo()
        {
            this.BackColor = Color.White;
            


        }

        
        [Category("RJ Code Advance")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Image ImagenFondo
        {
            get { return BackgroundImage; }
            set
            {
                this.BackgroundImage = value; // Asigna correctamente el valor
                this.Invalidate(); // Redibujar el control
                this.Refresh(); // Asegurar la actualización
            }
        }


        

    }

    //------------------------------------------------------------------------------------------------//
    public class titulo : Label
    {
        private Color borderColor = Color.Gray;
        private int borderSize = 2;
        private int borderRadius = 10;
        private string placeholderText = "Escribe aquí...";
        private bool isPlaceholder = true;
        public titulo()
        {

            
            this.ForeColor = Color.Gray;
            this.Text = placeholderText;
        }



        
        // Propiedad para agregar un Placeholder (Texto de sugerencia)
        [Category("RJ Code Advance")]
        [Browsable(true)]
        public string PlaceholderText
        {
            get { return placeholderText; }
            set { placeholderText = value; if (isPlaceholder) { this.Text = value; } }
        }

        // Cambia el tamaño del Label//
        [Category("RJ Code Advance")]
        [Browsable(true)]
        public Size CustomSize
        {
            get { return Size; }
            set
            {
                this.Size = value;
                  
            }
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (isPlaceholder)
            {
                this.Text = "";
                this.ForeColor = Color.Black;
                isPlaceholder = false;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (string.IsNullOrWhiteSpace(this.Text))
            {
                isPlaceholder = true;
                this.Text = placeholderText;
                this.ForeColor = Color.Gray;
            }
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int arcSize = radius * 2;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, arcSize, arcSize, 180, 90);
            path.AddArc(rect.Right - arcSize, rect.Y, arcSize, arcSize, 270, 90);
            path.AddArc(rect.Right - arcSize, rect.Bottom - arcSize, arcSize, arcSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - arcSize, arcSize, arcSize, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
    }

