<xsl:stylesheet version="1.0"
 xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
 xmlns:fo ="http://www.w3.org/1999/XSL/Format">
  <xsl:output method="xml" encoding="utf-8" />
  <xsl:template match="/">
    <fo:root>
      <fo:layout-master-set>
        <fo:simple-page-master master-name="A4"
        page-width="210mm" page-height="297mm" margin="1cm">
          <fo:region-body margin="16pt 0" />
          <fo:region-before extent="16pt" />
        </fo:simple-page-master>
      </fo:layout-master-set>
      <fo:page-sequence master-reference="A4">
        <fo:static-content flow-name="xsl-region-before">
          <fo:block>
            <fo:inline font-family="Arial" font-size="36pt" font-style="italic">
              <xsl:value-of select="@title"/>
            </fo:inline>
          </fo:block>
          <fo:block text-align="right">
            <fo:inline font-size="14pt" font-style="italic">
              Makes <xsl:value-of select="@portions"/> servings
            </fo:inline>
          </fo:block>
        </fo:static-content>
        <fo:flow flow-name="xsl-region-body">
          <xsl:apply-templates />
        </fo:flow>
      </fo:page-sequence>
    </fo:root>
  </xsl:template>
</xsl:stylesheet>