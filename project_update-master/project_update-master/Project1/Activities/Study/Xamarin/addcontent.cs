using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Vision;
using Android.Gms.Vision.Texts;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using FR.Ganfra.Materialspinner;
using Java.Util;
using Project1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Media;
using Xamarin.Essentials;
using SupportV7 = Android.Support.V7.App;

namespace Project1.Activities.Study.XamarinCourse
{
    [Activity(Label = "addcontent")]
    public class addcontent : Activity
    {
        TextInputLayout nameText, numberText, content1, content2, content3, content4, content5, content6;
        TextInputLayout title1, title2, title3, title4, title5, title6, categoryText;
        MaterialSpinner statusSpinner;
        Button submitButton;
        NestedScrollView linearLayout1;

        ImageView thisImage, camera1, camera2, camera3, camera4,
            camera5, camera6, camera7, camera8, camera9, camera10, camera11,
            camera12, camera13, camera14, camera15;



        EditText Edtname, Edtnumber, Edttitle1, Edtcontent1, Edttitle2, Edtcontent2, Edttitle3, Edtcontent3, Edttitle4,
            Edtcontent4, Edttitle5, Edtcontent5, Edttitle6, Edtcontent6, Edtcategory;

        ArrayAdapter<string> adapter;


        List<string> statusList;

        string status;
        private Context context;

        private SurfaceView cameraView;






        //Permisstion
        private CameraSource cameraSource;
        private const int RequestCameraPermissionID = 1001;
        readonly string[] permissionGroup =
        {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.Camera
        };



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addxamarin);
        //    SetupStatusPinner(); 

            thisImage = (ImageView)FindViewById(Resource.Id.thisImage);
            nameText = (TextInputLayout)FindViewById(Resource.Id.nameText);
            numberText = (TextInputLayout)FindViewById(Resource.Id.numberText);
            content1 = (TextInputLayout)FindViewById(Resource.Id.content1Text);
            content2 = (TextInputLayout)FindViewById(Resource.Id.content2Text);
            content3 = (TextInputLayout)FindViewById(Resource.Id.content3Text);
            content4 = (TextInputLayout)FindViewById(Resource.Id.contetn4Text);
            content5 = (TextInputLayout)FindViewById(Resource.Id.content5Text);
            content6 = (TextInputLayout)FindViewById(Resource.Id.content6Text);
            statusSpinner = (MaterialSpinner)FindViewById(Resource.Id.statusSpinner);

            categoryText = (TextInputLayout)FindViewById(Resource.Id.categoryText);

            title1 = (TextInputLayout)FindViewById(Resource.Id.title1Text);
            title2 = (TextInputLayout)FindViewById(Resource.Id.title2Text);
            title3 = (TextInputLayout)FindViewById(Resource.Id.title3Text);
            title4 = (TextInputLayout)FindViewById(Resource.Id.title4Text);
            title5 = (TextInputLayout)FindViewById(Resource.Id.title5Text);
            title6 = (TextInputLayout)FindViewById(Resource.Id.title6Text);

            linearLayout1 = (NestedScrollView)FindViewById(Resource.Id.linearLayout1);

            SetupStatusPinner();

            submitButton = (Button)FindViewById(Resource.Id.submitBtn);
            submitButton.Click += SubmitButton_Click;
            ControlCamera();
            // Create your application here

            RequestPermissions(permissionGroup, 0);

            ControEditText();  

        }



        public void ControEditText()
        {
            Edtname = (EditText)FindViewById(Resource.Id.Edtname);
            Edtnumber  = (EditText)FindViewById(Resource.Id.Edtnumber);
            Edttitle1 = (EditText)FindViewById(Resource.Id.Edttitle1);
            Edtcontent1 = (EditText)FindViewById(Resource.Id.Edtcontent1);
            Edttitle2 = (EditText)FindViewById(Resource.Id.Edttitle2);
            Edtcontent2 = (EditText)FindViewById(Resource.Id.Edtcontent2);
            Edttitle3 = (EditText)FindViewById(Resource.Id.Edttitle3);
            Edtcontent3 = (EditText)FindViewById(Resource.Id.Edtcontent3);
            Edttitle4 = (EditText)FindViewById(Resource.Id.Edttitle4);
            Edtcontent4 = (EditText)FindViewById(Resource.Id.Edtcontent4);
            Edttitle5 = (EditText)FindViewById(Resource.Id.Edttitle5);

            Edtcontent5 = (EditText)FindViewById(Resource.Id.Edtcontent5);
            Edttitle6 = (EditText)FindViewById(Resource.Id.Edttitle6);
            Edtcontent6 = (EditText)FindViewById(Resource.Id.Edtcontent6);
            Edtcategory = (EditText)FindViewById(Resource.Id.Edtcategory);
            
        }

        public void ControlCamera()
        {
            camera1 = (ImageView)FindViewById(Resource.Id.camera1);
            camera1.Click += Camera1_Click;

            camera2 = (ImageView)FindViewById(Resource.Id.camera2);
            camera2.Click += Camera2_Click;

            camera3 = (ImageView)FindViewById(Resource.Id.camera3);
            camera3.Click += Camera3_Click;

            camera4 = (ImageView)FindViewById(Resource.Id.camera4);
            camera4.Click += Camera4_Click;

            camera5 = (ImageView)FindViewById(Resource.Id.camera5);
            camera5.Click += Camera5_Click;

            camera6 = (ImageView)FindViewById(Resource.Id.camera6);
            camera6.Click += Camera6_Click;

            camera7 = (ImageView)FindViewById(Resource.Id.camera7);
            camera7.Click += Camera7_Click;

            camera8 = (ImageView)FindViewById(Resource.Id.camera8);
            camera8.Click += Camera8_Click;

            camera9 = (ImageView)FindViewById(Resource.Id.camera9);
            camera9.Click += Camera9_Click;


            camera10 = (ImageView)FindViewById(Resource.Id.camera10);
            camera10.Click += Camera10_Click;


            camera11 = (ImageView)FindViewById(Resource.Id.camera11);
            camera11.Click += Camera11_Click;

            camera12 = (ImageView)FindViewById(Resource.Id.camera12);
            camera12.Click += Camera12_Click;

            camera13 = (ImageView)FindViewById(Resource.Id.camera13);
            camera13.Click += Camera13_Click;

            camera14 = (ImageView)FindViewById(Resource.Id.camera14);
            camera14.Click += Camera14_Click;

            camera15 = (ImageView)FindViewById(Resource.Id.camera15);
            camera15.Click += Camera15_Click;
        }

        private void Camera15_Click(object sender, EventArgs e)
        {
            TakePhoto15();
        }

        private void Camera14_Click(object sender, EventArgs e)
        {
            TakePhoto14();
        }

        private void Camera13_Click(object sender, EventArgs e)
        {
            TakePhoto13();
        }

        private void Camera12_Click(object sender, EventArgs e)
        {
            TakePhoto12();
        }

        private void Camera11_Click(object sender, EventArgs e)
        {
            TakePhoto11();
        }

        private void Camera10_Click(object sender, EventArgs e)
        {
            TakePhoto10();
        }

        private void Camera9_Click(object sender, EventArgs e)
        {
            TakePhoto9();
        }

        private void Camera8_Click(object sender, EventArgs e)
        {
            TakePhoto8();
        }

        private void Camera7_Click(object sender, EventArgs e)
        {
            TakePhoto7();
        }

        private void Camera6_Click(object sender, EventArgs e)
        {
            TakePhoto6();
        }

        private void Camera5_Click(object sender, EventArgs e)
        {
            TakePhoto5();
        }

        private void Camera4_Click(object sender, EventArgs e)
        {
            TakePhoto4();
        }

        private void Camera3_Click(object sender, EventArgs e)
        {
            TakePhoto3();
        }

        private void Camera2_Click(object sender, EventArgs e)
        {
            TakePhoto2();
        }

        private void Camera1_Click(object sender, EventArgs e)
        {
            TakePhoto1();
        }

        public void Vibrate()
        {
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string name = nameText.EditText.Text;
            string number = numberText.EditText.Text;
            string Content1 = content1.EditText.Text;
            string Content2 = content2.EditText.Text;
            string Content3 = content3.EditText.Text;
            string Content4 = content4.EditText.Text;
            string Content5 = content5.EditText.Text;
            string Content6 = content6.EditText.Text;
            string category = categoryText.EditText.Text;

            string Title1 = title1.EditText.Text;
            string Title2 = title2.EditText.Text;
            string Title3 = title3.EditText.Text;
            string Title4 = title4.EditText.Text;
            string Title5 = title5.EditText.Text;
            string Title6 = title6.EditText.Text;

            if (name.Length < 1)
            {
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Please enter text", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                Vibrate();
                return;
            }

            else if (number.Length < 1)
            {
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Please enter text", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                Vibrate();
                return;
            }

            HashMap aluminiInfo = new HashMap();
            aluminiInfo.Put("Name", name);
            aluminiInfo.Put("Number", number);
            aluminiInfo.Put("Content1", Content1);
            aluminiInfo.Put("Content2", Content2);
            aluminiInfo.Put("Content3", Content3);
            aluminiInfo.Put("Content4", Content4);
            aluminiInfo.Put("Content5", Content5);
            aluminiInfo.Put("Content6", Content6);

            aluminiInfo.Put("Title1", Title1);
            aluminiInfo.Put("Title2", Title2);
            aluminiInfo.Put("Title3", Title3);
            aluminiInfo.Put("Title4", Title4);
            aluminiInfo.Put("Title5", Title5);
            aluminiInfo.Put("Title6", Title6);
            aluminiInfo.Put("Category", category);

            SupportV7.AlertDialog.Builder saveDataAlert = new SupportV7.AlertDialog.Builder(this);
            saveDataAlert.SetTitle("SAVE XAMARIN INFORMATION");
            saveDataAlert.SetMessage("Are you sure?");
            saveDataAlert.SetPositiveButton("Continue", (senderAlert, args) =>
            {

                if (status == "Xamarin")
                {
                    DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("Xamarin").Push();
                    newAluminRef.SetValue(aluminiInfo);
                    saveDataAlert.Dispose();
                    Snackbar snackbar = Snackbar.Make(linearLayout1, "Add to Xamarin Success", Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Green);
                    snackbar.Show();
                    //DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("alumini").Push();
                    //    newAluminRef.SetValue(aluminiInfo);
                    //    this.Dismiss();

                }

               
                else if (status == "Interview")
                {
                    DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("Interview").Push();
                    newAluminRef.SetValue(aluminiInfo);
                    saveDataAlert.Dispose();
                    Snackbar snackbar = Snackbar.Make(linearLayout1, "Add to Interview Success", Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Green);
                    snackbar.Show();

                }



                else if (status == "Question&Answer")
                {
                    DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("Question&Answer").Push();
                    newAluminRef.SetValue(aluminiInfo);
                    saveDataAlert.Dispose();
                    Snackbar snackbar = Snackbar.Make(linearLayout1, "Add to Question & Answer Success", Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Green);
                    snackbar.Show();

                }

            });
            saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {
                saveDataAlert.Dispose();
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Add Failed !! Please Again", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
            });

                saveDataAlert.Show();

           

        }
        public void SetupStatusPinner()
        {
            statusList = new List<string>();
            statusList.Add("Xamarin");
            statusList.Add("Interview");
            statusList.Add("Question&Answer");
          

            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, statusList);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

         statusSpinner.Adapter = adapter;
            statusSpinner.ItemSelected += StatusSpinner_ItemSelected;
        }


        async void TakePhoto1()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImage.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                Edtname.Text = strBuilder.ToString();

            }


        }
        async void TakePhoto2()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImage.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                Edtnumber.Text = strBuilder.ToString();

            }


        }

        async void TakePhoto3()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImage.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                Edttitle1.Text = strBuilder.ToString();

            }


        }



        async void TakePhoto4()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImage.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                Edtcontent1.Text = strBuilder.ToString();

            }


        }


        async void TakePhoto5()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImage.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                Edttitle2.Text = strBuilder.ToString();

            }


        }



        async void TakePhoto6()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImage.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                Edtcontent2.Text = strBuilder.ToString();

            }


        }
        async void TakePhoto7()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImage.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                Edttitle3.Text = strBuilder.ToString();

            }


        }



        async void TakePhoto8()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImage.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                Edtcontent3.Text = strBuilder.ToString();

            }


        }


        async void TakePhoto9()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImage.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                Edttitle4.Text = strBuilder.ToString();

            }


        }


        async void TakePhoto10()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImage.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                Edtcontent4.Text = strBuilder.ToString();

            }


        }

        async void TakePhoto11()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImage.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                Edttitle5.Text = strBuilder.ToString();

            }


        }
        async void TakePhoto12()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImage.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                Edtcontent5.Text = strBuilder.ToString();

            }


        }

        async void TakePhoto13()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImage.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                Edttitle6.Text = strBuilder.ToString();

            }


        }

        async void TakePhoto14()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImage.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                Edtcontent6.Text = strBuilder.ToString();

            }


        }

        async void TakePhoto15()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImage.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                Edtcategory.Text = strBuilder.ToString();

            }


        }

        private void StatusSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != -1)
            {
                status = statusList[e.Position];
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {

            switch (requestCode)
            {
                case RequestCameraPermissionID:
                    {
                        if (grantResults[0] == Permission.Granted)
                        {
                            cameraSource.Start(cameraView.Holder);
                        }
                    }
                    break;
            }
            //  Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }

    }
}