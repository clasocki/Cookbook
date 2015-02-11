<xsl:stylesheet version="1.0"
 xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
 xmlns:fo ="http://www.w3.org/1999/XSL/Format">
  <xsl:output method="xml" encoding="utf-8" />
  
  <xsl:template match="/">
    <fo:root>
      <fo:layout-master-set>
        <fo:simple-page-master master-name="A4"
            page-height="300mm" page-width="200mm"
            margin-top="20mm" margin-bottom="20mm"
            margin-left="20mm" margin-right="20mm">

          <fo:region-body
            margin-top="20mm" margin-bottom="10mm"
            margin-left="0mm" margin-right="0mm"/>
          <fo:region-before extent="20mm" />
          <fo:region-after extent="20mm"/>
        </fo:simple-page-master>
      </fo:layout-master-set>
      <fo:page-sequence master-reference="A4">
        <fo:static-content flow-name="xsl-region-before">
          <fo:block font-family="Arial" font-size="36pt" font-style="italic" border-bottom="4px solid rgb(79,129,189)">
            <xsl:value-of select="/Recipe/title"/>
          </fo:block>
        </fo:static-content>
        <fo:flow flow-name="xsl-region-body">
          <xsl:apply-templates/>
        </fo:flow>
      </fo:page-sequence>
    </fo:root>
  </xsl:template>
  
  <xsl:template match="preparationTime">
    <fo:block text-align="right" font-size="14pt" font-style="italic">
        <xsl:text>Preparation time: </xsl:text>
        <xsl:value-of select="time"/>
        <xsl:text> </xsl:text>
        <xsl:value-of select="units"/>
    </fo:block>
  </xsl:template>

  <xsl:template match="ingredients">
    <fo:list-block provisional-distance-between-starts="18pt"
                   provisional-label-separation="3pt"
                   space-after="20mm">
      <xsl:for-each select="ingredient">
        <fo:list-item>
          <fo:list-item-label end-indent="label-end()">
            <fo:block>&#x2022;</fo:block>
          </fo:list-item-label>
          <fo:list-item-body start-indent="body-start()">
            <fo:block>
              <xsl:value-of select="name"/>
              <xsl:text>       </xsl:text>
              <fo:inline font-weight="bold">
                <xsl:value-of select="quantity"/>
                <xsl:text> </xsl:text>
                <xsl:value-of select="units"/>
              </fo:inline>
            </fo:block>
          </fo:list-item-body>
        </fo:list-item>
      </xsl:for-each>
    </fo:list-block>
  </xsl:template>

  <xsl:template match="content">
      <xsl:for-each select="section">
        <fo:block space-after="3mm">
            <fo:block font-size="14pt" 
                      font-style="italic"
                      font-weight="bold"
                      space-after="2mm">
              <xsl:number/>
              <xsl:text>) </xsl:text>
              <xsl:value-of select="@name"/>
            </fo:block>
            <fo:block>
              <xsl:value-of select="."/>
            </fo:block>
        </fo:block>
      </xsl:for-each>
  </xsl:template>
  
  <xsl:template match="Recipe">
    <fo:block text-align="right" font-size="14pt" font-style="italic">
        Makes <xsl:value-of select="portions"/> servings
    </fo:block>
    
    <xsl:apply-templates select="preparationTime"/>
    
    <fo:block font-family="Verdana" 
              font-size="20pt" 
              font-style="normal" 
              border-bottom="0.5px solid rgb(79,129,189)"
              space-after="3mm">
      Ingredients
    </fo:block>
    
    <xsl:apply-templates select="ingredients"/>
    
    <fo:block font-family="Verdana"
              font-size="20pt"
              font-style="normal"
              border-bottom="0.5px solid rgb(79,129,189)"
              space-after="3mm">
      Method
    </fo:block>
    
    <xsl:apply-templates select="content"/>
  </xsl:template>
</xsl:stylesheet>