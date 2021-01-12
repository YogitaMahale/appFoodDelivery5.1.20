 
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
 
using System.Configuration;
 
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using Microsoft.AspNetCore.Http;
using appFoodDelivery.Models;

namespace appFoodDelivery.PDF
{
    public class ExportToPDF
    {
       
        public MemoryStream GeneratePDF(List<HotelEarningViewModel> obj)
        {

            
            
            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
            MemoryStream PDFData = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, PDFData);

            var titleFont = FontFactory.GetFont("Arial", 6, Font.NORMAL);
            var titleFontBlue = FontFactory.GetFont("Arial", 14, Font.NORMAL, Color.BLUE);
            //var boldTableFont = FontFactory.GetFont("Arial", 6, Font.BOLD);//8
            var boldTableFont = FontFactory.GetFont("Arial", 6, Font.BOLD);//8
            var boldTableFont1 = FontFactory.GetFont("Arial", 8, Font.BOLD);//8
            var bodyFont = FontFactory.GetFont("Arial", 7, Font.NORMAL);//8
            var EmailFont = FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK);//8
            var footerfont = FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK);//8
            var newfontt = FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK);//8
            Color TabelHeaderBackGroundColor = WebColors.GetRGBColor("#EEEEEE");

            Rectangle pageSize = writer.PageSize;
            // Open the Document for writing
            pdfDoc.Open();
            //Add elements to the document here


           


            //#region Top table
            //// Create the header table 
            //PdfPTable headertable = new PdfPTable(3);
            //headertable.HorizontalAlignment = 0;
            //headertable.WidthPercentage = 100;
            //headertable.SetWidths(new float[] { 100f, 320f, 120f });  // then set the column's __relative__ widths
            //headertable.DefaultCell.Border = Rectangle.NO_BORDER;
            //headertable.DefaultCell.Border = Rectangle.BOX; //for testing           

            //iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/images/invoice.png"));
            //// //logo.ScaleToFit(100,80);

            //logo.ScaleToFit(70, 120);
            //{
            //    PdfPCell pdfCelllogo = new PdfPCell(logo);
            //    pdfCelllogo.Border = Rectangle.NO_BORDER;
            //    pdfCelllogo.BorderColorBottom = new Color(System.Drawing.Color.Black);
            //    pdfCelllogo.BorderWidthBottom = 1f;
            //    pdfCelllogo.Top = 0;
            //    headertable.AddCell(pdfCelllogo);
            //}

            //{
            //    PdfPCell middlecell = new PdfPCell();
            //    middlecell.Border = Rectangle.NO_BORDER;
            //    middlecell.BorderColorBottom = new Color(System.Drawing.Color.Black);
            //    middlecell.BorderWidthBottom = 1f;
            //    headertable.AddCell(middlecell);
            //}

            //{
            //    PdfPTable nested = new PdfPTable(1);
            //    nested.DefaultCell.Border = Rectangle.NO_BORDER;

            //    PdfPCell nextPostCell3 = new PdfPCell(new Phrase("Morya Tools", boldTableFont1));
            //    nextPostCell3.Border = Rectangle.NO_BORDER;
            //    nested.AddCell(nextPostCell3);

            //    PdfPCell nextPostCell1 = new PdfPCell(new Phrase("(0253)3014578", boldTableFont1));
            //    nextPostCell1.Border = Rectangle.NO_BORDER;
            //    nested.AddCell(nextPostCell1);
            //    PdfPCell nextPostCell2 = new PdfPCell(new Phrase(" kshatriya.enterprises@gmail.com", boldTableFont1));
            //    nextPostCell2.Border = Rectangle.NO_BORDER;
            //    nested.AddCell(nextPostCell2);

            //    //PdfPCell nextPostCell4 = new PdfPCell(new Phrase("The Leading Manufacturing Company For exercise Notebook & All kind of stationary products", titleFont));
            //    //nextPostCell4.Border = Rectangle.NO_BORDER;
            //    //nested.AddCell(nextPostCell4);


            //    //PdfPCell nextPostCell1 = new PdfPCell(new Phrase("+91-8412887171", boldTableFont));
            //    //nextPostCell1.Border = Rectangle.NO_BORDER;
            //    //nested.AddCell(nextPostCell1);
            //    //PdfPCell nextPostCell2 = new PdfPCell(new Phrase("anant@adhikarindustries.com,"+"\n"+"info@adhikarindustries.com", boldTableFont));
            //    //nextPostCell2.Border = Rectangle.NO_BORDER;
            //    //nested.AddCell(nextPostCell2);
            //    //PdfPCell nextPostCell3 = new PdfPCell(new Phrase("www.adhikarindustries.com", boldTableFont));
            //    //nextPostCell3.Border = Rectangle.NO_BORDER;
            //    //nested.AddCell(nextPostCell3);
            //    //PdfPCell nextPostCell4 = new PdfPCell(new Phrase("The Leading Manufacturing Company For "+"\n"+"exercise Notebook & All kind of stationary products", titleFont));
            //    //nextPostCell4.Border = Rectangle.NO_BORDER;
            //    //nested.AddCell(nextPostCell4);
            //    nested.AddCell("");


            //    PdfPCell nesthousing = new PdfPCell(nested);
            //    nesthousing.Border = Rectangle.NO_BORDER;
            //    nesthousing.BorderColorBottom = new Color(System.Drawing.Color.Black);
            //    nesthousing.BorderWidthBottom = 1f;
            //    // nesthousing.Rowspan = 5;
            //    nesthousing.PaddingBottom = 10f;
            //    headertable.AddCell(nesthousing);
            //    PdfPTable tablenew = new PdfPTable(3);
            //    PdfPCell cellnew = new PdfPCell(new Phrase("Header spanning 3 columns"));
            //    cellnew.Colspan = 3;
            //    cellnew.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            //    tablenew.AddCell(cellnew);
            //    tablenew.AddCell("Col 1 Row 1");
            //    tablenew.AddCell("Col 2 Row 1");
            //    tablenew.AddCell("Col 3 Row 1");
            //    tablenew.AddCell("Col 1 Row 2");
            //    tablenew.AddCell("Col 2 Row 2");
            //    tablenew.AddCell("Col 3 Row 2");
            //    // headertable.AddCell(tablenew);


            //    PdfPCell nesthousingn = new PdfPCell(tablenew);
            //    nesthousingn.Border = Rectangle.NO_BORDER;
            //    nesthousingn.BorderColorBottom = new Color(System.Drawing.Color.Black);
            //    nesthousingn.BorderWidthBottom = 1f;
            //    // nesthousing.Rowspan = 5;
            //    nesthousingn.PaddingBottom = 10f;
            //    headertable.AddCell(nesthousingn);
            //    // pdfDoc.Add(tablenew);
            //}


            //// invoice rperte

            //PdfPTable Invoicetable2 = new PdfPTable(1);
            //Invoicetable2.HorizontalAlignment = 0;
            //Invoicetable2.WidthPercentage = 100;
            //Invoicetable2.SetWidths(new float[] { 500f });  // then set the column's __relative__ widths
            //Invoicetable2.DefaultCell.Border = Rectangle.NO_BORDER;

            //{


            //    PdfPTable tablenew = new PdfPTable(3);
            //    PdfPCell cellnew = new PdfPCell(new Phrase("TAX INVOICE"));
            //    cellnew.Colspan = 3;
            //    cellnew.BackgroundColor = new Color(System.Drawing.Color.Khaki);


            //    PdfPTable nested1 = new PdfPTable(2);
            //    //nested1.DefaultCell.Border = Rectangle.NO_BORDER;

            //    //PdfPCell nextPostCell1 = new PdfPCell(new Phrase("0000000000", newfontt ));
            //    //nextPostCell1.Border = Rectangle.NO_BORDER;
            //    //nested1.AddCell(nextPostCell1);


            //    //PdfPCell pdfCelllogo = new PdfPCell();
            //    //nested1.AddCell(pdfCelllogo);


            //    //PdfPCell nextPostCell2 = new PdfPCell(new Phrase("111", newfontt));
            //    //nextPostCell2.Colspan = 2;
            //    //nextPostCell2.HorizontalAlignment = Element.ALIGN_LEFT;
            //    //nested1.AddCell(nextPostCell2);


            //    //PdfPCell nextPostCell3 = new PdfPCell(new Phrase("22", newfontt));
            //    //nextPostCell3.Colspan = 2;
            //    //nextPostCell3.HorizontalAlignment = Element.ALIGN_LEFT;
            //    //nested1.AddCell(nextPostCell3);

            //    PdfPCell cellnew1 = new PdfPCell(nested1);

            //    cellnew1.BackgroundColor = new Color(System.Drawing.Color.Khaki);


            //    string InvoiceName = string.Empty;
            //    string fff = dt.Tables[0].Rows[0]["oid"].ToString().Trim();


            //    PdfPCell cellnew2 = new PdfPCell(new Phrase("GSTIN: 27BOOPS0449L1Z9 " + "\n" + "Invoice No : " + InvoiceName + "" + "\n" + "Invoice Date: " + dt.Tables[0].Rows[0]["orderdate"] + "" + "\n" + "State:Maharashtra" + "                                                     " + "State Code : 27" + "\n" + "HSNCode:48202000", EmailFont));

            //    PdfPCell cellnew3 = new PdfPCell(new Phrase("Transporatation Mode:" + "" + "\n" + "Vehicle Number :" + "" + "\n" + "Date Of Supply:" + "" + "\n" + "Purchase order no & Date :" + "" + "\n" + "Place of suppliy:" + "" + "\n" + "Sale officer :" + "Nashik", EmailFont));

            //    PdfPCell cellnew4 = new PdfPCell(new Phrase("                              " + "Detailed Of Receiver/Billed To:" + "                              ", EmailFont));

            //    PdfPCell cellnew5 = new PdfPCell(new Phrase("                            " + "Detailed of Consignee/Shiped To: " + "        ", EmailFont));
            //    cellnew.Colspan = 2;
            //    PdfPCell cellnew6 = new PdfPCell(new Phrase("Name:" + dt.Tables[2].Rows[0]["NAME"] + "" + "\n" + "Address:" + dt.Tables[2].Rows[0]["address"] + "\n" + "Properiter:" + "  " + "\n" + "GSTIN:" + dt.Tables[2].Rows[0]["gstno"] + "\n" + "", EmailFont));


            //    PdfPCell cellnew7 = new PdfPCell(new Phrase("", EmailFont));


            //    cellnew.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            //    tablenew.AddCell(cellnew);
            //    tablenew.AddCell(cellnew1);


            //    cellnew2.Colspan = 2;
            //    tablenew.AddCell(cellnew2);

            //    //cellnew3.Colspan = 2;
            //    tablenew.AddCell(cellnew3);


            //    cellnew4.Colspan = 2;
            //    tablenew.AddCell(cellnew4);

            //    cellnew5.Colspan = 2;
            //    tablenew.AddCell(cellnew5);


            //    cellnew6.Colspan = 2;
            //    tablenew.AddCell(cellnew6);

            //    cellnew7.Colspan = 2;
            //    tablenew.AddCell(cellnew7);


            //    PdfPCell nesthousingn = new PdfPCell(tablenew);
            //    nesthousingn.Border = Rectangle.NO_BORDER;

            //    nesthousingn.PaddingBottom = 10f;
            //    Invoicetable2.AddCell(nesthousingn);



            //}
            ////invoice repeat        
            //pdfDoc.Add(headertable);
            //Invoicetable2.SpacingBefore = 3f;
            ////  Invoicetable. = 10f;

            //// pdfDoc.Add(Invoicetable);

            //pdfDoc.Add(Invoicetable2);


            //#endregion

            #region Items Table
            //Create body table
            PdfPTable itemTable = new PdfPTable(3);

            itemTable.HorizontalAlignment = 0;
            itemTable.WidthPercentage = 100;
            // itemTable.SetWidths(new float[] {2,30,6,6,6,6,6,6,6,6,6,4,4,7 });  // then set the column's __relative__ widths
            itemTable.SetWidths(new float[] { 25,25,50});
            itemTable.SpacingAfter = 10;

            itemTable.DefaultCell.Border = Rectangle.BOX;

            PdfPCell cell1 = new PdfPCell(new Phrase("OrderId", boldTableFont));
            cell1.BackgroundColor = TabelHeaderBackGroundColor;
            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            itemTable.AddCell(cell1);

            PdfPCell cell2 = new PdfPCell(new Phrase("Date", boldTableFont));
            cell2.BackgroundColor = TabelHeaderBackGroundColor;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            itemTable.AddCell(cell2);

            PdfPCell cell3 = new PdfPCell(new Phrase("Customer", boldTableFont));
            cell3.BackgroundColor = TabelHeaderBackGroundColor;
            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            itemTable.AddCell(cell3);


            int i = 1;
            foreach (var item in obj)
            {

                //name of product
                var _phrase1 = new Phrase();
                _phrase1.Add(new Chunk(item.id, EmailFont));
                i++;
                PdfPCell descCells = new PdfPCell(_phrase1);
                descCells.HorizontalAlignment = 0;
                descCells.PaddingLeft = 10f;
                descCells.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                itemTable.AddCell(descCells);

                var _phrase = new Phrase();
                _phrase.Add(new Chunk(item.placedate, EmailFont));
                PdfPCell descCell = new PdfPCell(_phrase);
                descCell.HorizontalAlignment = 0;
                descCell.PaddingLeft = 10f;
                descCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                itemTable.AddCell(descCell);

                //totalqty
                PdfPCell amountCell = new PdfPCell(new Phrase(item.customerName, bodyFont));
                amountCell.HorizontalAlignment = 1;
                amountCell.PaddingLeft = 10f;
                amountCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                itemTable.AddCell(amountCell);

              


            }

            
            //PdfPCell totalAmtCell1 = new PdfPCell(new Phrase("  ", bodyFont));
            //totalAmtCell1.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
            //totalAmtCell1.HorizontalAlignment = 1;
            //itemTable.AddCell(totalAmtCell1);

            //PdfPCell totalAmtCell2 = new PdfPCell(new Phrase("Total", FontFactory.GetFont("arial", 7, Font.BOLD)));
            //totalAmtCell2.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
            //totalAmtCell2.HorizontalAlignment = 1;
            //itemTable.AddCell(totalAmtCell2);

            ////PdfPCell totalAmtCell3 = new PdfPCell(new Phrase(Total_TotalQty.ToString(), bodyFont));
            //PdfPCell totalAmtCell3 = new PdfPCell(new Phrase("", bodyFont));
            //totalAmtCell3.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
            //totalAmtCell3.HorizontalAlignment = 1;
            //itemTable.AddCell(totalAmtCell3);

            ////PdfPCell totalAmtCell4 = new PdfPCell(new Phrase(Total_Pricee.ToString(), bodyFont));
            //PdfPCell totalAmtCell4 = new PdfPCell(new Phrase("", bodyFont));
            ////PdfPCell totalAmtCell4 = new PdfPCell(new Phrase(Math.Round(Convert.ToDouble(totalqty.ToString()),2).ToString() , bodyFont));
            //totalAmtCell4.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
            //totalAmtCell4.HorizontalAlignment = 1;
            //itemTable.AddCell(totalAmtCell4);

            ////PdfPCell totalAmtCell5 = new PdfPCell(new Phrase(Total_Discount.ToString(), bodyFont));
            //PdfPCell totalAmtCell5 = new PdfPCell(new Phrase("", bodyFont));
            //totalAmtCell5.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
            //totalAmtCell5.HorizontalAlignment = 1;
            //itemTable.AddCell(totalAmtCell5);

            //PdfPCell totalAmtCell6 = new PdfPCell(new Phrase("".ToString(), bodyFont));
            //totalAmtCell6.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
            //totalAmtCell6.HorizontalAlignment = 1;
            //itemTable.AddCell(totalAmtCell6);

            //PdfPCell totalAmtCell7 = new PdfPCell(new Phrase("".ToString(), bodyFont));
            ////PdfPCell totalAmtCell7 = new PdfPCell(new Phrase(Math.Round(Convert.ToDouble(totaltaxable.ToString()),2).ToString(), bodyFont));
            //totalAmtCell7.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
            //totalAmtCell7.HorizontalAlignment = 1;
            //itemTable.AddCell(totalAmtCell7);



            //PdfPCell totalAmtCell8 = new PdfPCell(new Phrase("".ToString(), bodyFont));
            //totalAmtCell8.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
            //totalAmtCell8.HorizontalAlignment = 1;
            //itemTable.AddCell(totalAmtCell8);


            //PdfPCell totalAmtCell9 = new PdfPCell(new Phrase("".ToString(), bodyFont));
            //totalAmtCell9.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
            //totalAmtCell9.HorizontalAlignment = 1;
            //itemTable.AddCell(totalAmtCell9);




            //PdfPCell totalAmtCell14 = new PdfPCell(new Phrase(dt.Tables[0].Rows[0]["totalamount"].ToString(), bodyFont));
            ////PdfPCell totalAmtCell14 = new PdfPCell(new Phrase(Math.Round(Convert.ToDouble(total.ToString()), 2).ToString(), bodyFont));
            //totalAmtCell14.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
            //totalAmtCell14.HorizontalAlignment = 1;
            //itemTable.AddCell(totalAmtCell14);

             

            pdfDoc.Add(itemTable);
         

            #endregion

            pdfDoc.NewPage();






            //////////////////////////////////////

            pdfDoc.Close();


            return PDFData;


        }


    }
}
