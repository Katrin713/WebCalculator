using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCalclator
{
    public partial class Calculator : System.Web.UI.Page
    {
        private string writingText
        {
            get
            {

                return (Session["writingText"] != null) ? (string)Session["writingText"] : "";
            }
            set
            {
                Session["writingText"] = value;
                ResultBox.Text = writingText;
            }
        }
        private bool canBeOperation
        {
            get
            {
                return (Session["canBeOperation"] != null) ? (bool)Session["canBeOperation"] : false;
            }
            set
            {
                Session["canBeOperation"] = value;
            }
        }
        private bool canBeMinus
        {
            get
            {
                return (Session["canBeMinus"] != null) ? (bool)Session["canBeMinus"] : true;
            }
            set
            {
                Session["canBeMinus"] = value;
            }
        }
        private bool canBeSem
        {
            get
            {
                return (Session["canBeSem"] != null) ? (bool)Session["canBeSem"] : true;
            }
            set
            {
                Session["canBeSem"] = value;
            }
        }
        private bool beforDigitClick
        {
            get
            {
                return (Session["beforDigitClick"] != null) ? (bool)Session["beforDigitClick"] : false;
            }
            set
            {
                Session["beforDigitClick"] = value;
            }
        }
        private bool lastClickedButtonIsSem
        {
            get
            {
                return (Session["lastClickedButtonIsSem"] != null) ? (bool)Session["lastClickedButtonIsSem"] : false;
            }
            set
            {
                Session["lastClickedButtonIsSem"] = value;
            }
        }
        // Load a page
        protected void Page_Load(object sender, EventArgs e)
        {
            // using incapsulation
            // to write expression on calculator
            writingText = writingText;
        }
        
        // click on digit button
        protected void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            // get number's number
            string nameOfButton = b.ID.Substring(6);
            switch (nameOfButton)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    canBeOperation = true;
                    canBeMinus = true;
                    writingText += nameOfButton;
                    beforDigitClick = true;
                    lastClickedButtonIsSem = false;
                    break;
                case "Plus":
                    if (writingText.Length < 1 && canBeOperation == false || writingText == " - ")
                        return;
                    if (lastClickedButtonIsSem)
                        writingText = writingText.Substring(0, writingText.Length - 1);
                    if (canBeOperation)
                    {
                        writingText += " + ";
                        canBeOperation = false;
                    }
                    else
                        if (writingText[writingText.Length - 2] == '-' && (writingText[writingText.Length - 4] > '9' || writingText[writingText.Length - 4] < '0'))
                        writingText = writingText.Substring(0, writingText.Length - 5) + "+ ";
                    else
                        writingText = writingText.Substring(0, writingText.Length - 2) + "+ ";
                    canBeMinus = false;
                    canBeSem = true;
                    lastClickedButtonIsSem = false;
                    beforDigitClick = false;
                    break;
                case "Divide":
                    if (writingText.Length < 1 && canBeOperation == false || writingText == " - ")
                        return;
                    if (lastClickedButtonIsSem)
                        writingText = writingText.Substring(0, writingText.Length - 1);
                    if (canBeOperation)
                    {
                        writingText += " / ";
                        canBeOperation = false;
                    }
                    else
                        if (writingText[writingText.Length - 2] == '-' && (writingText[writingText.Length - 4] > '9' || writingText[writingText.Length - 4] < '0'))
                            writingText = writingText.Substring(0, writingText.Length - 5) + "/ ";
                        else
                            writingText = writingText.Substring(0, writingText.Length - 2) + "/ ";
                    canBeMinus = true;
                    lastClickedButtonIsSem = false;
                    canBeSem = true;
                    beforDigitClick = false;
                    break;
                case "Mult":
                    if (writingText.Length < 1 && canBeOperation == false || writingText == " - ")
                        return;
                    if (lastClickedButtonIsSem)
                        writingText = writingText.Substring(0, writingText.Length - 1);
                    if (canBeOperation)
                    {
                        writingText += " * ";
                        canBeOperation = false;
                    }
                    else
                        if (writingText[writingText.Length - 2] == '-' && (writingText[writingText.Length - 4] > '9' || writingText[writingText.Length - 4] < '0'))
                        writingText = writingText.Substring(0, writingText.Length - 5) + "* ";
                    else
                        writingText = writingText.Substring(0, writingText.Length - 2) + "* ";
                    canBeMinus = true;
                    lastClickedButtonIsSem = false;
                    beforDigitClick = false;
                    canBeSem = true;
                    break;
                case "Minus":
                    if (lastClickedButtonIsSem)
                        writingText = writingText.Substring(0, writingText.Length - 1);
                    if (canBeMinus)
                    {
                        writingText += " - ";
                        canBeMinus = false;
                    }
                    else
                        writingText = writingText.Substring(0, writingText.Length - 2) + "- ";
                    canBeOperation = false;
                    canBeSem = true;
                    lastClickedButtonIsSem = false;
                    beforDigitClick = false;
                    break;
                case "Sem":
                    if (canBeSem)
                    {
                        if (beforDigitClick)
                            writingText += ",";
                        else
                            writingText += "0,";
                        canBeOperation = true;
                        canBeSem = false;
                        lastClickedButtonIsSem = true;
                    }
                    break;
            }
            
        }
        // clean writing
        protected void clean_Click(object sender, EventArgs e)
        {
            canBeMinus = true;
            lastClickedButtonIsSem = false;
            canBeOperation = false;
            canBeSem = true;
            beforDigitClick = false;
            writingText = "";
        }
        CountExpression expression = new CountExpression();
        protected void result_Click(object sender, EventArgs e)
        {
            if (!canBeOperation)
                writingText = writingText.Substring(0, writingText.Length - 2);
            writingText = expression.Counting(writingText);
        }
        
    }
}