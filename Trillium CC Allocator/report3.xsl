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
  
  <xsl:key name="group-by-company" match="Allocations/Allocation" use="Company" />
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
        .divBillTo{position: absolute; margin-top: 5px; margin-left: 5px;}
        .large{font-weight:bold;}
        .divInvoice{padding-top:5px;}
        .wnorm{width: 75px}
        .wbig{width: 100px}
        .amountTotal{text-align:right; font-weight:bold; width: 100%;}
        .amount{text-align:right; width: 100%;}
      </style>
    </head>
  <body>
    <div align="center" class="divInvoice">
      <span class="large">TRANSACTIONS BY COMPANY</span>
    </div>
    <hr></hr>
    <table align="center" class="reportTable">
      <tr class="headerRow">
        <th class="wbig">Cardholder Name</th>
        <th class="wnorm">Process Date</th>
        <th class="whide">Merchant Name/Location</th>
        <th class="whide">Account</th>
        <th class="wnorm">
          <span class="amount">Amount</span>
        </th>
        <th class="whide">
          Description
        </th>
      </tr>
      <xsl:for-each select="Allocations/Allocation[count(. | key('group-by-company', Company)[1]) = 1]">
        <tr class="accountRow">
          <td colspan="6">
            <xsl:value-of select="Company" />
          </td>
        </tr>
        <xsl:for-each select="key('group-by-company', Company)">
          <xsl:sort select="Process_x0020_Date"/>
          <tr class="itemRow">
            <td class="whide">
              <xsl:value-of select="Cardholder_x0020_Name"/>
            </td>
            <td class="wnorm">
              <xsl:apply-templates select="Process_x0020_Date"/>
            </td>
            <td class="whide">
              <xsl:value-of select="Merchant_x0020_Name_x002F_Location"/>
            </td>
            <td class="whide">
              <xsl:value-of select="Account"/>
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
          <td colspan="4" class="amountTotal">Company Total:</td>
          <td>
            <span class="amountTotal">
              <xsl:value-of select="format-number(sum(key('group-by-company', Company)/Amount), '$###,###,##0.00')"/>
            </span>
          </td>
        </tr>
      </xsl:for-each>
      <tr>
        <td colspan="4" class="amountTotal">Statement Total:</td>
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