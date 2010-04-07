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

  <xsl:key name="group-by-chargeid" match="Split" use="ChargeID" />

  <xsl:template match="Allocations">
    <html>
      <head>
        <style type="text/css">
          table.reportTable {border-collapse:collapse;
          border-width: 1px; border-spacing: 0; border-collapse: collapse; table-layout: fixed; width: 100%;
          }
          table.reportTable, .reportTable td, th {border-width: 1px; border-color: black; border-style: solid;}
          .headerRow{background-color: #cccccc; }
          .accountRow{background-color: #eeeeee; font-weight:bold;}
          td, th{font-weight:normal; font-family:Cambria,times; font-size: 8.0pt; padding: 2px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap; }
          th {text-align: left;}
          div{font-family:Calibri,Arial,sans-serif; font-size: 8.0pt;}
          .large{font-weight:bold;}
          .divInvoice{padding-top:5px;}
          .wnorm{width: 70px}
          .amountTotal{text-align:right; font-weight:bold; width: 100%;}
          .amount{text-align:right; width: 100%;}
        </style>
      </head>
      <body>
        <div align="center" class="divInvoice">
          <span class="large">CREDIT CARD ALLOCATION</span>
          <br/>
          <xsl:value-of select="Allocation/Cardholder_x0020_Name"/>
          <br/>
        </div>
        <hr></hr>
        <table class="reportTable" align="center">
          <tr class="headerRow">
            <th class="wnorm">Process Date</th>
            <th class="whide">Merchant Name/Location</th>
            <th class="wnorm">
              <span class="amount">Amount</span>
            </th>
            <th class="wbig">Company</th>
            <th class="whide">Account</th>
            <th class="whide">Description</th>
          </tr>
          <xsl:for-each select="Allocation">
            <xsl:sort select="Process_x0020_Date"/>
            <tr class="itemRow">
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
              <td class="wbig">
                <xsl:apply-templates select="Company"/>
              </td>
              <td class="whide">
                <xsl:value-of select="Account"/>
              </td>
              <td class="whide">
                <xsl:value-of select="Description"/>
              </td>
            </tr>
          </xsl:for-each>
          <tr>
            <td colspan="2" class="amountTotal">Total:</td>
            <td>
              <span class="amountTotal">
                <xsl:value-of select="format-number(sum(Allocation/Amount), '$###,###,##0.00')"/>
              </span>
            </td>
            <td colspan="3"></td>
          </tr>
        </table>
        <br/>
        <xsl:if test="count(Split) > 0">
          <br/>
          <table class="reportTable" align="center">
            <tr class="headerRow">
              <th class="wbig">Company</th>
              <th class="whide">Account</th>
              <th class="wnorm">Amount</th>
            </tr>
            <xsl:for-each select="Split[count(. | key('group-by-chargeid', ChargeID)[1]) = 1]">
              <xsl:sort select="Process_x0020_Date"/>
              <tr class="accountRow">
                <td colspan="3">
                  Split # <xsl:value-of select="substring(ChargeID,10)" />
                </td>
              </tr>
              <xsl:for-each select="key('group-by-chargeid', ChargeID)">
                <tr>
                  <td>
                    <xsl:value-of select="Company"/>
                  </td>
                  <td>
                    <xsl:value-of select="Account"/>
                  </td>
                  <td>
                    <xsl:apply-templates select="Amount"/>
                  </td>
                </tr>
              </xsl:for-each>
            </xsl:for-each>
          </table>
        </xsl:if>
      </body>
    </html>
  </xsl:template>


  <xsl:template match="Company">
    <xsl:variable name="pCompany" select="."/>
    <xsl:choose>
      <xsl:when test="$pCompany = 'Split'">
        Split (<xsl:value-of select="substring(preceding-sibling::ChargeID,10)"/>)
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="."/>
      </xsl:otherwise>
    </xsl:choose>
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