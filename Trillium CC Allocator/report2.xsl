<?xml version='1.0'?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:fn="urn:trillium" version="1.0">
  <msxsl:script language="C#" implements-prefix="fn">
    <![CDATA[
   
    		public string GetDateTime(string data, string format)
        {
          DateTime dt = DateTime.Parse(data);
          return dt.ToString(format);
        }
     
     ]]>
  </msxsl:script>
  
  <xsl:key name="group-by-account" match="Allocations/Allocation" use="Account" />
  <xsl:template match="/">
  <html>
    <head>
      <style type="text/css">
        table.reportTable {border-collapse:collapse;
        border-width: 1px; border-spacing: 0; border-collapse: collapse; table-layout: fixed; width: 100%;
        }
        table.reportTable, .reportTable td, th {border-width: 1px; border-color: black; border-style: solid;}
        .accountRow{background-color: #eeeeee; font-weight:bold;}
        .headerRow, th{background-color: #cccccc; font-size: 8.0pt; font-weight:normal;}
        td, th {font-family:Cambria,times; padding: 2px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap; }
        th {text-align: left;}
        td {font-size: 8.0pt;}
        div{font-family:Calibri,Arial,sans-serif; font-size: 8.0pt;}
        .divBillTo{float: left; width: 25%; text-align: left;}
        .divInvoice{float: left; width: 49%; text-align: center;}
        .divAvenue{float: right; width: 25%; text-align: right;}
        .left{float: left; text-align: center; width: 49%;}
        .right{float: right; text-align: center; width: 49%;}
        .header{width: 100%;}
        #mid{padding-bottom: 5px;}
        .large{font-weight:bold;}
        .wnorm{width: 70px}
        .wbig{width: 20%}
        .amountTotal{text-align:right; font-weight:bold; width: 100%;}
        .amount{text-align:right; width: 100%;}
      </style>
    </head>
  <body>
    <div class="header">
    <div class="divBillTo">
      <span class="large">BILL TO:</span><br/>
      <xsl:value-of select="Allocations/Companies/Company"/><br/>
      <xsl:value-of select="Allocations/Companies/Address1"/><br/>
      <xsl:value-of select="Allocations/Companies/Address2"/><br/>
    </div>
    <div class="divInvoice">
      <span class="large">INVOICE</span>
      <div class="header" id="mid">
        <span class="left">
          <span class="large">Invoice Date: </span><xsl:value-of select="Allocations/StatementInfo/InvoiceDate"/>
        </span>
        <span class="right">
          <span class="large">Statement Date: </span>
          <xsl:value-of select="Allocations/StatementInfo/StatementDate"/>
        </span>
      </div>
        <span class="large">Number:</span>___________________________
    </div>
    <div class="divAvenue">
      <span class="large">PAYABLE TO:</span><br/>
      <xsl:value-of select="Allocations/StatementInfo/PayeeName"/><br/>
      230 W 5th St<br/>
      Tempe, AZ 85281<br/>
      (480) 294-6300<br/>
    </div>
    </div>
      <hr></hr>
    <table align="center" class="reportTable">
      <tr class="headerRow">
        <th class="wbig">Cardholder Name</th>
        <th class="wnorm">Process Date</th>
        <th class="whide">Merchant Name/Location</th>
        <th class="wnorm">
          <span class="amount">Amount</span>
        </th>
        <th class="whide">Description</th>
      </tr>
      <xsl:for-each select="Allocations/Allocation[count(. | key('group-by-account', Account)[1]) = 1]">
        <tr class="accountRow">
          <td colspan="5">
            <xsl:value-of select="/Allocations/Companies/Prefix"/>
            -
            <xsl:value-of select="Account" />
          </td>
        </tr>
        <xsl:for-each select="key('group-by-account', Account)">
          <xsl:sort select="Process_x0020_Date"/>
          <tr class="itemRow">
            <td class="wbig">
              <xsl:value-of select="Cardholder_x0020_Name"/>
            </td>
            <td class="wnorm">
              <xsl:apply-templates select="Process_x0020_Date"/>
            </td>
            <td class="whide">
              <xsl:value-of select="Merchant_x0020_Name_x002F_Location"/>
            </td>
            <td class="wnorm">
              <span class="amount">
                <xsl:apply-templates select="Amount"/>
              </span>
            </td>
            <td class="whide">
              <xsl:value-of select="Description"/>
            </td>
          </tr>
        </xsl:for-each>
        <tr>
          <td colspan="3" class="amountTotal">Account Total:</td>
          <td>
            <span class="amountTotal">
              <xsl:value-of select="format-number(sum(key('group-by-account', Account)/Amount), '$###,###,##0.00')"/>
            </span>
          </td>
        </tr>
      </xsl:for-each>
      <tr>
        <td colspan="3" class="amountTotal">Company Total:</td>
        <td>
          <span class="amountTotal">
            <xsl:value-of select="format-number(sum(Allocations/Allocation/Amount), '$###,###,##0.00')"/>
          </span>
        </td>
      </tr>
    </table>
  </body>
  </html>
</xsl:template>

  
  <xsl:template match="Process_x0020_Date">
    <xsl:variable name="pDate" select="."/>
    <xsl:value-of select="fn:GetDateTime($pDate, 'd')"/>
  </xsl:template>

  <xsl:template match="Amount">
    <xsl:variable name="amnt" select="."/>
    <xsl:value-of select="format-number($amnt, '$###,###,##0.00')"/>
  </xsl:template>
  
</xsl:stylesheet>