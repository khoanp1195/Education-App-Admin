package crc645e1f78be6b80dd76;


public class UserProfileAdapterViewHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Project1.Adapter.UserProfileAdapterViewHolder, Project1", UserProfileAdapterViewHolder.class, __md_methods);
	}


	public UserProfileAdapterViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == UserProfileAdapterViewHolder.class)
			mono.android.TypeManager.Activate ("Project1.Adapter.UserProfileAdapterViewHolder, Project1", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
