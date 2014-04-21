using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

public class easyPrint : System.Drawing.Printing.PrintDocument
{

    /// <summary>
    /// Property variable for the Font the user wishes to use
    /// </summary>
    /// <remarks></remarks>
    private Font font;

    /// <summary>
    /// Static variable to hold the current character	
    /// we're currently dealing with.
    /// </summary>
    static int curChar;


    /// <summary>
    /// Property variable for the text to be printed
    /// </summary>
    /// <remarks></remarks>
    private string text;




    /// <summary>
    /// a varible to hold the printDialog object
    /// </summary>
    private System.Windows.Forms.PrintDialog printDialog1;

    /// <summary>
    /// Constructor to initialize our printing object
    /// and the text it's supposed to be printing
    /// </summary>
    /// <remarks></remarks>
    public easyPrint()
        : base()
    {
    }
   /// <summary>
   /// these method prints the string 
   /// </summary>
   /// <param name="str">Text that will be printed</param>
    public void  PrintString(string str)
    {

        printDialog1 = new PrintDialog();
        if (printDialog1.ShowDialog() == DialogResult.OK)
        {
            //Set the file stream
            //Set our Text property value
            text = str;
        }
        this.Print();
    }

    /// <summary>
    /// Override the default onbeginPrint method of the PrintDocument Object
    /// </summary>
    /// <param name=e></param>
    /// <remarks></remarks>
    protected override void OnBeginPrint(System.Drawing.Printing.PrintEventArgs e)
    {
        // Run base code
        base.OnBeginPrint(e);

        //Check to see if the user provided a font
        //if they didn't then we default to Times New Roman
        if (font == null)
        {
            //Create the font we need
            font = new Font("Times New Roman", 10);
        }

    }

    /// <summary>
    /// Override the default OnPrintPage method of the PrintDocument
    /// </summary>
    /// <param name=e></param>
    /// <remarks>This provides the print logic for our document</remarks>
    protected override void OnPrintPage(System.Drawing.Printing.PrintPageEventArgs e)
    {
        // Run base code
        base.OnPrintPage(e);

        //Declare local variables needed

        int printHeight;
        int printWidth;
        int leftMargin;
        int rightMargin;
        Int32 lines;
        Int32 chars;

        //Set print area size and margins
        {
            printHeight = base.DefaultPageSettings.PaperSize.Height - base.DefaultPageSettings.Margins.Top - base.DefaultPageSettings.Margins.Bottom;
            printWidth = base.DefaultPageSettings.PaperSize.Width - base.DefaultPageSettings.Margins.Left - base.DefaultPageSettings.Margins.Right;
            leftMargin = base.DefaultPageSettings.Margins.Left;  //X
            rightMargin = base.DefaultPageSettings.Margins.Top;  //Y
        }

        //Check if the user selected to print in Landscape mode
        //if they did then we need to swap height/width parameters
        if (base.DefaultPageSettings.Landscape)
        {
            int tmp;
            tmp = printHeight;
            printHeight = printWidth;
            printWidth = tmp;
        }

        //Now we need to determine the total number of lines
        //we're going to be printing
        Int32 numLines = (int)printHeight / font.Height;

        //Create a rectangle printing are for our document
        RectangleF printArea = new RectangleF(leftMargin, rightMargin, printWidth, printHeight);

        //Use the StringFormat class for the text layout of our document
        StringFormat format = new StringFormat(StringFormatFlags.LineLimit);

        //Fit as many characters as we can into the print area     

        e.Graphics.MeasureString(text.Substring(RemoveZeros(curChar)), font, new SizeF(printWidth, printHeight), format, out chars, out lines);

        //Print the page
        e.Graphics.DrawString(text.Substring(RemoveZeros(curChar)), font, Brushes.Black, printArea, format);

        //Increase current char count
        curChar += chars;

        //Detemine if there is more text to print, if
        //there is the tell the printer there is more coming
        if (curChar < text.Length)
        {
            e.HasMorePages = true;
        }
        else
        {
            e.HasMorePages = false;
            curChar = 0;
        }
    }





    /// <summary>
    /// Function to replace any zeros in the size to a 1
    /// Zero's will mess up the printing area
    /// </summary>
    /// <param name=value>Value to check</param>
    /// <returns></returns>
    /// <remarks></remarks>
    protected int RemoveZeros(int value)
    {
        //Check the value passed into the function,
        //if the value is a 0 (zero) then return a 1,
        //otherwise return the value passed in
        switch (value)
        {
            case 0:
                return 1;
            default:
                return value;
        }
    }

}
