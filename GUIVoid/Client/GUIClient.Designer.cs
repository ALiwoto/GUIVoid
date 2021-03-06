using Microsoft.Xna.Framework;
using static GUIVoid.Constants.ThereIsGConstants;

namespace GUIVoid.Client
{
	partial class GUIClient
	{
		//-------------------------------------------------
		#region Initialize Method's Region
		/// <summary>
		/// The initializa component method which should be present
		/// in all of `.designer.cs` files.
		/// This method should remains private, please do NOT
		/// make it public or internal.
		/// <!--
		/// Since: GUIVoid 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		private void InitializaComponent()
		{
			Universe.SetUpUniverse();
			// check if the game is the single one process or not.
			if (Actions.IsSingleOne() || !this.RunSingleInstance)
			{
				//AppSettings.DECoder = new DECoder();
				// check if we can manage to create a single-one
				// provider peeker or not.
				// this method should try to create a memory space for us,
				// which will be visible to another instances.
				if (Actions.CreateSingleOne() || !this.RunSingleInstance)
				{
					// it means the game is the single-instance,
					// so you can now run the game.
					// so, create a new instance of the game client.
					// set the verified property to true,
					// to show the single-instance has been verified.
					this._g = new(true, this);
				}
				else
				{
					return;
				}
			}
			else
			{
				try
				{
					// it means this process is not the single-one,
					// and another game process is already running, so
					// send a request to another universe and tell them:
					// make your ass up and active your planet :/
					Universe.Universe_Request();
				}
				catch
				{
					;
				}

				return;
			}
			//---------------------------------------------
			//news:
			
			//---------------------------------------------
			//names:
			//fontAndTextAligns:
			//priorities:
			//sizes:
			//ownering:
			//locations:
			//movements:
			//colors:
			//test.ChangeForeColor(Color.Red);
			//enableds:
			//texts:
			//images:
			//applyAndShow:
			//events:
			//---------------------------------------------
			//addRanges:
			//---------------------------------------------
		}
		#endregion
		//-------------------------------------------------
		#region Graphical Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region event Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region overrided Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region ordinary Method's Region
		/// <summary>
		/// Start the application and enter a loop.
		/// Please notice that after calling this method, 
		/// you won't be able to run anything else (in your Main() method).
		/// You have to use events and such methods to interact with 
		/// your users.
		/// When overriding this method, please make sure to
		/// call <c>base.Start()</c> at the end.
		/// </summary>
		public virtual void Start()
		{
			this.IsStarted = true;
			this._g?.Run();
		}
		/// <summary>
		/// Make this application a single runner so if the user
		/// open up this application twice, it won't start the client
		/// again.
		/// Basically, it will just close the new application instance.
		/// In windows, it will work even if the application is started
		/// in another directory, but in linux, it won't work.
		/// If user open it up in another directory (in linux), the
		/// client will start itself in usual mode.
		/// <!--
		/// Since: GUIVoid 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual void MakeSingleRunner()
		{
			if (!this.IsStarted)
			{
				this.RunSingleInstance = true;
			}
		}
		/// <summary>
		/// Apply the changes we have made to Graphical objects
		/// and structures like Size, Location, etc...
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 27 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		internal void ApplyGraphicsChange()
		{
			this._g?.GraphicsDM?.ApplyChanges();
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		/// <summary>
		/// Change the size of this client.
		/// If you pass zero or a less number for w or h
		/// parameters, this method will ignore it.
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 27 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="w">
		/// The new width. If it's zero or less, 
		/// this method will ignore it, so the width won't change at all.
		/// </param>
		/// <param name="h">
		/// The new height. If it's zero or less, 
		/// this method will ignore it, so the height won't change at all.
		/// </param>
		public virtual void ChangeSize(int w, int h)
		{
			if (this._g == null)
			{
				return;
			}
			var bw = w <= Universe.DEFAULT_Z_BASE;
			var bh = h <= Universe.DEFAULT_Z_BASE;
			w = w >= MIN_WIDTH ? w : MIN_WIDTH;
			h = h >= MIN_HEIGHT ? h : MIN_HEIGHT;
			if (bw && bh)
			{
				return;
			}
			if (!bw)
			{
				this._g.GraphicsDM.PreferredBackBufferWidth = w;
			}
			if (!bh)
			{
				this._g.GraphicsDM.PreferredBackBufferHeight = h;
			}
			if (!this.IsStarted)
			{
				if (!bw)
				{
					this._g.GameUniverse.DefaultWidth = w;
				}
				if (!bh)
				{
					this._g.GameUniverse.DefaultHeight = h;
				}
			}
			else
			{
				this.ApplyGraphicsChange();
			}
		}
		/// <summary>
		/// Change the size of this client.
		/// If you pass zero or a less number for X or Y
		/// parameters, this method will ignore it.
		/// Please take note that <see cref="Point.X"/> means Width,
		/// and <see cref="Point.Y"/> means Height.
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 27 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="size">
		/// The new Size, which is in <see cref="Point"/> format.
		/// If <see cref="Point.X"/> or <see cref="Point.Y"/> is zero or less, 
		/// this method will ignore it, so the width or height 
		/// won't change at all.
		/// </param>
		public virtual void ChangeSize(Point size)
		{
			if (size == Point.Zero)
			{
				return;
			}
			this.ChangeSize(size.X, size.Y);
		}
		/// <summary>
		/// Change the size of this client.
		/// If you pass zero or a less number for w or h
		/// parameters, this method will ignore it.
		/// This method will simply call <see cref="ChangeSize(int, int)"/>,
		/// so the <see cref="System.Single"/> parameters will become 
		/// <see cref="System.Int32"/>.
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 27 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="w">
		/// The new width. If it's zero or less, 
		/// this method will ignore it, so the width won't change at all.
		/// This parameter will be converted to int32, 
		/// so if you enter <c>2.3</c>, it will become <c>2</c>.
		/// </param>
		/// <param name="h">
		/// The new height. If it's zero or less, 
		/// this method will ignore it, so the height won't change at all.
		/// This parameter will be converted to int32, 
		/// so if you enter <c>2.3</c>, it will become <c>2</c>.
		/// </param>
		public virtual void ChangeSize(float w, float h)
		{
			this.ChangeSize((int)w, (int)h);
		}
		public virtual void MultipleSize(float factorX, float factorY)
		{
			this.ChangeSize(factorX * Width, factorY * Height);
		}
		public virtual void MultipleSize(float factor)
		{
			this.MultipleSize(factor, factor);
		}

		/// <summary>
		/// Change the location of this client to the specified coordinates
		/// on the user's screen. This method will immediately effect
		/// the client's location.
		/// There is no limitation applied to X and Y parameters.
		/// (other than <see cref="System.Int32"/>'s limitations).
		/// Just notice that if you use negetive numbers for X and Y, it may
		/// not effect the client's location in some operating systems.
		/// But you won't get any Exception for it.
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 27 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="x">
		/// The x. It can be zero or less.
		/// </param>
		/// <param name="y">
		/// The y. It can be zero or less.
		/// </param>
		public virtual void ChangeLocation(int x, int y)
		{
			this.ChangeLocation(new Point(x, y));
		}
		/// <summary>
		/// Change the location of this client to the specified coordinates
		/// on the user's screen. This method will immediately effect
		/// the client's location.
		/// There is no limitation applied to X and Y properties in 
		/// Point. (other than <see cref="System.Int32"/>'s limitations).
		/// Just notice that if you use negetive numbers for X and Y, it may
		/// not effect the client's location in some operating systems.
		/// But you won't get any Exception for it.
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 27 11:02;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="point">
		/// The location in Point format. It can be zero or less.
		/// </param>
		public virtual void ChangeLocation(Point point)
		{
			if (this._g != null)
			{
				if (this._g.Window != null)
				{
					try
					{
						this._g.Window.Position = point;
						if (!this.IsStarted)
						{
							this._g.GameUniverse.DefaultPoint = point;
						}
						else
						{
							this.ApplyGraphicsChange();
						}
					}
					catch
					{
						return;
					}
				}
			}
		}
		#endregion
		//-------------------------------------------------
	}
}