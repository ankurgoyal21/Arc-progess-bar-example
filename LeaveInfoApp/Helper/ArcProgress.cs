using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Icu.Text;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
//using Java.Lang;

namespace LeaveInfoApp
{
    public class ArcProgress : View
    {
        private Paint _paint;
        private Paint _textPaint;

        private RectF _rectF = new RectF();
        private float _strokeWidth;
        private float _suffixTextSize;
        private float _bottomTextSize;
        private string _bottomText;
        private float _textSize;
        private Color _textColor;
        private float _progress = 0;
        private int _max;
        private Color _finishedStrokeColor;
        private Color _unfinishedStrokeColor;
        private float _arcAngle;
        private string _suffixText = "%";
        private float _suffixTextPadding;
        private float _arcBottomHeight;
        private Color _default_finished_color = Color.White;
        private Color _default_unfinished_color = Color.Rgb(72, 106, 176);
        private Color _default_text_color = Color.Rgb(66, 145, 241);
        private float _default_suffix_text_size;
        private float _default_suffix_padding;
        private float _default_bottom_text_size;
        private float _default_stroke_width;
        private string _default_suffix_text;
        private int _default_max = 100;
        private float _default_arc_angle = 360 * 0.8f;
        private float _default_text_size;
        private int _min_size;

        private static string INSTANCE_STATE = "saved_instance";
        private static string INSTANCE_STROKE_WIDTH = "stroke_width";
        private static string INSTANCE_SUFFIX_TEXT_SIZE = "suffix_text_size";
        private static string INSTANCE_SUFFIX_TEXT_PADDING = "suffix_text_padding";
        private static string INSTANCE_BOTTOM_TEXT_SIZE = "bottom_text_size";
        private static string INSTANCE_BOTTOM_TEXT = "bottom_text";
        private static string INSTANCE_TEXT_SIZE = "text_size";
        private static string INSTANCE_TEXT_COLOR = "text_color";
        private static string INSTANCE_PROGRESS = "progress";
        private static string INSTANCE_MAX = "max";
        private static string INSTANCE_FINISHED_STROKE_COLOR = "finished_stroke_color";
        private static string INSTANCE_UNFINISHED_STROKE_COLOR = "unfinished_stroke_color";
        private static string INSTANCE_ARC_ANGLE = "arc_angle";
        private static string INSTANCE_SUFFIX = "suffix";

        public ArcProgress(Context context) : base(context, null)
        {
        }

        public ArcProgress(Context context, IAttributeSet attrs) : base(context, attrs, 0)
        {
            _default_text_size = Utils.Sp2Px(Resources, 18);
            _min_size = (int)Utils.Dp2Px(Resources, 100);
            _default_text_size = Utils.Sp2Px(Resources, 40);
            _default_suffix_text_size = Utils.Sp2Px(Resources, 15);
            _default_suffix_padding = Utils.Dp2Px(Resources, 4);
            _default_suffix_text = "%";
            _default_bottom_text_size = Utils.Sp2Px(Resources, 10);
            _default_stroke_width = Utils.Dp2Px(Resources, 4);

            TypedArray attributes = context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.ArcProgress, 0, 0);
            InitByAttributes(attributes);
            attributes.Recycle();

            InitPainters();
        }

        public ArcProgress(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {


            _default_text_size = Utils.Sp2Px(Resources, 18);
            _min_size = (int)Utils.Dp2Px(Resources, 100);
            _default_text_size = Utils.Sp2Px(Resources, 40);
            _default_suffix_text_size = Utils.Sp2Px(Resources, 15);
            _default_suffix_padding = Utils.Dp2Px(Resources, 4);
            _default_suffix_text = "%";
            _default_bottom_text_size = Utils.Sp2Px(Resources, 10);
            _default_stroke_width = Utils.Dp2Px(Resources, 4);

            TypedArray attributes = context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.ArcProgress, defStyleAttr, 0);
            InitByAttributes(attributes);
            attributes.Recycle();

            InitPainters();
        }

        protected void InitByAttributes(TypedArray attributes)
        {
            _finishedStrokeColor = attributes.GetColor(Resource.Styleable.ArcProgress_arc_finished_color, _default_finished_color);
            _unfinishedStrokeColor = attributes.GetColor(Resource.Styleable.ArcProgress_arc_unfinished_color, _default_unfinished_color);
            _textColor = attributes.GetColor(Resource.Styleable.ArcProgress_arc_text_color, _default_text_color);
            _textSize = attributes.GetDimension(Resource.Styleable.ArcProgress_arc_text_size, _default_text_size);
            _arcAngle = attributes.GetFloat(Resource.Styleable.ArcProgress_arc_angle, _default_arc_angle);
            SetMax(attributes.GetInt(Resource.Styleable.ArcProgress_arc_max, _default_max));
            SetProgress(attributes.GetFloat(Resource.Styleable.ArcProgress_arc_progress, 0));
            _strokeWidth = attributes.GetDimension(Resource.Styleable.ArcProgress_arc_stroke_width, _default_stroke_width);
            _suffixTextSize = attributes.GetDimension(Resource.Styleable.ArcProgress_arc_suffix_text_size, _default_suffix_text_size);
            _suffixText = TextUtils.IsEmpty(attributes.GetString(Resource.Styleable.ArcProgress_arc_suffix_text)) ? _default_suffix_text : attributes.GetString(Resource.Styleable.ArcProgress_arc_suffix_text);
            _suffixTextPadding = attributes.GetDimension(Resource.Styleable.ArcProgress_arc_suffix_text_padding, _default_suffix_padding);
            _bottomTextSize = attributes.GetDimension(Resource.Styleable.ArcProgress_arc_bottom_text_size, _default_bottom_text_size);
            _bottomText = attributes.GetString(Resource.Styleable.ArcProgress_arc_bottom_text);
        }

        protected void InitPainters()
        {
            _textPaint = new TextPaint();
            _textPaint.Color = _textColor;
            _textPaint.TextSize = (_textSize);
            _textPaint.AntiAlias = (true);

            _paint = new Paint();
            _paint.Color = _default_unfinished_color;
            _paint.AntiAlias = (true);
            _paint.StrokeWidth = (_strokeWidth);
            _paint.SetStyle(Paint.Style.Stroke);
            _paint.StrokeCap = (Paint.Cap.Round);
        }

        public override void Invalidate()
        {
            InitPainters();
            base.Invalidate();
        }

        public float GetStrokeWidth()
        {
            return _strokeWidth;
        }

        public void SetStrokeWidth(float strokeWidth)
        {
            this._strokeWidth = strokeWidth;
            this.Invalidate();
        }

        public float GetSuffixTextSize()
        {
            return _suffixTextSize;
        }

        public void SetSuffixTextSize(float suffixTextSize)
        {
            this._suffixTextSize = suffixTextSize;
            this.Invalidate();
        }

        public string GetBottomText()
        {
            return _bottomText;
        }

        public void SetBottomText(string bottomText)
        {
            this._bottomText = bottomText;
            this.Invalidate();
        }

        public float GetProgress()
        {
            return _progress;
        }

        public void SetProgress(float progress)
        {
            this._progress = Convert.ToInt64(new DecimalFormat("#.##").Format(progress));

            if (this._progress > GetMax())
            {
                this._progress %= GetMax();
            }
            Invalidate();
        }

        public int GetMax()
        {
            return _max;
        }

        public void SetMax(int max)
        {
            if (max > 0)
            {
                this._max = max;
                Invalidate();
            }
        }

        public float GetBottomTextSize()
        {
            return _bottomTextSize;
        }

        public void SetBottomTextSize(float bottomTextSize)
        {
            this._bottomTextSize = bottomTextSize;
            this.Invalidate();
        }

        public float GetTextSize()
        {
            return _textSize;
        }

        public void SetTextSize(float textSize)
        {
            this._textSize = textSize;
            this.Invalidate();
        }

        public int GetTextColor()
        {
            return _textColor;
        }

        public void SetTextColor(Color textColor)
        {
            this._textColor = textColor;
            this.Invalidate();
        }

        public int GetFinishedStrokeColor()
        {
            return _finishedStrokeColor;
        }

        public void SetFinishedStrokeColor(Color finishedStrokeColor)
        {
            this._finishedStrokeColor = finishedStrokeColor;
            this.Invalidate();
        }

        public int GetUnfinishedStrokeColor()
        {
            return _unfinishedStrokeColor;
        }

        public void SetUnfinishedStrokeColor(Color unfinishedStrokeColor)
        {
            this._unfinishedStrokeColor = unfinishedStrokeColor;
            this.Invalidate();
        }

        public float GetArcAngle()
        {
            return _arcAngle;
        }

        public void SetArcAngle(float arcAngle)
        {
            this._arcAngle = arcAngle;
            this.Invalidate();
        }

        public string GetSuffixText()
        {
            return _suffixText;
        }

        public void SetSuffixText(string suffixText)
        {
            this._suffixText = suffixText;
            this.Invalidate();
        }

        public float GetSuffixTextPadding()
        {
            return _suffixTextPadding;
        }

        public void SetSuffixTextPadding(float suffixTextPadding)
        {
            this._suffixTextPadding = suffixTextPadding;
            this.Invalidate();
        }

        protected override int SuggestedMinimumHeight => _min_size;

        protected override int SuggestedMinimumWidth => _min_size;
        
        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            SetMeasuredDimension(widthMeasureSpec, heightMeasureSpec);
            int width = MeasureSpec.GetSize(widthMeasureSpec);
            _rectF.Set(_strokeWidth / 2f, _strokeWidth / 2f, width - _strokeWidth / 2f, MeasureSpec.GetSize(heightMeasureSpec) - _strokeWidth / 2f);
            float radius = width / 2f;
            float angle = (360 - _arcAngle) / 2f;
            _arcBottomHeight = radius * (float)(1 - System.Math.Cos(angle / 180 * System.Math.PI));
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            float startAngle = 270 - _arcAngle / 2f;
            float finishedSweepAngle = _progress / (float)GetMax() * _arcAngle;
            float finishedStartAngle = startAngle;
            if (_progress == 0) finishedStartAngle = 0.01f;
            _paint.Color = _unfinishedStrokeColor;
            canvas.DrawArc(_rectF, startAngle, _arcAngle, false, _paint);
            _paint.Color = _finishedStrokeColor;
            canvas.DrawArc(_rectF, finishedStartAngle, finishedSweepAngle, false, _paint);

            string text = Convert.ToString(_max - GetProgress());
            if (!TextUtils.IsEmpty(text))
            {
                _textPaint.Color = _textColor;
                _textPaint.TextSize = (_textSize);
                float textHeight = _textPaint.Descent() + _textPaint.Ascent();
                float textBaseline = (Height - textHeight) / 2.0f;
                canvas.DrawText(text, (Width - _textPaint.MeasureText(text)) / 2.0f, textBaseline, _textPaint);
                _textPaint.TextSize = (_suffixTextSize);
                float suffixHeight = _textPaint.Descent() + _textPaint.Ascent();
                canvas.DrawText(_suffixText, Width / 2.0f + _textPaint.MeasureText(text) + _suffixTextPadding, textBaseline + textHeight - suffixHeight, _textPaint);
            }

            if (_arcBottomHeight == 0)
            {
                float radius = Width / 2f;
                float angle = (360 - _arcAngle) / 2f;
                _arcBottomHeight = radius * (float)(1 - System.Math.Cos(angle / 180 * System.Math.PI));
            }

            if (!TextUtils.IsEmpty(GetBottomText()))
            {
                _textPaint.TextSize = (_bottomTextSize);
                float bottomTextBaseline = Height - _arcBottomHeight - (_textPaint.Descent() + _textPaint.Ascent()) / 2;
                canvas.DrawText(GetBottomText(), (Width - _textPaint.MeasureText(GetBottomText())) / 2.0f, bottomTextBaseline, _textPaint);
            }
        }
    }
}