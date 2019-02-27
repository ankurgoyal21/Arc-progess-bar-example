package md5775d7a3771bee03b7d03a80ab1473aad;


public class LeavesDetailsAdapter_LeavesViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("LeaveInfoApp.LeavesDetailsAdapter+LeavesViewHolder, LeaveInfoApp", LeavesDetailsAdapter_LeavesViewHolder.class, __md_methods);
	}


	public LeavesDetailsAdapter_LeavesViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == LeavesDetailsAdapter_LeavesViewHolder.class)
			mono.android.TypeManager.Activate ("LeaveInfoApp.LeavesDetailsAdapter+LeavesViewHolder, LeaveInfoApp", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
