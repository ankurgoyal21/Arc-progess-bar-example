package md5775d7a3771bee03b7d03a80ab1473aad;


public class ArcProgress
	extends android.view.View
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_invalidate:()V:GetInvalidateHandler\n" +
			"n_getSuggestedMinimumHeight:()I:GetGetSuggestedMinimumHeightHandler\n" +
			"n_getSuggestedMinimumWidth:()I:GetGetSuggestedMinimumWidthHandler\n" +
			"n_onMeasure:(II)V:GetOnMeasure_IIHandler\n" +
			"n_onDraw:(Landroid/graphics/Canvas;)V:GetOnDraw_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("LeaveInfoApp.ArcProgress, LeaveInfoApp", ArcProgress.class, __md_methods);
	}


	public ArcProgress (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ArcProgress.class)
			mono.android.TypeManager.Activate ("LeaveInfoApp.ArcProgress, LeaveInfoApp", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ArcProgress (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ArcProgress.class)
			mono.android.TypeManager.Activate ("LeaveInfoApp.ArcProgress, LeaveInfoApp", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ArcProgress (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ArcProgress.class)
			mono.android.TypeManager.Activate ("LeaveInfoApp.ArcProgress, LeaveInfoApp", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public ArcProgress (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == ArcProgress.class)
			mono.android.TypeManager.Activate ("LeaveInfoApp.ArcProgress, LeaveInfoApp", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void invalidate ()
	{
		n_invalidate ();
	}

	private native void n_invalidate ();


	public int getSuggestedMinimumHeight ()
	{
		return n_getSuggestedMinimumHeight ();
	}

	private native int n_getSuggestedMinimumHeight ();


	public int getSuggestedMinimumWidth ()
	{
		return n_getSuggestedMinimumWidth ();
	}

	private native int n_getSuggestedMinimumWidth ();


	public void onMeasure (int p0, int p1)
	{
		n_onMeasure (p0, p1);
	}

	private native void n_onMeasure (int p0, int p1);


	public void onDraw (android.graphics.Canvas p0)
	{
		n_onDraw (p0);
	}

	private native void n_onDraw (android.graphics.Canvas p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
