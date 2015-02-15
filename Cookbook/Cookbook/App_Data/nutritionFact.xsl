<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:import href="nutritionLabel.xsl"/>
  <xsl:output method="html" indent="yes"/> 
  <xsl:param name="quantity" />

  <xsl:template match="nutrition-fact">
    <xsl:call-template name="nutrition-label">
      <xsl:with-param name="base" select="."/>
    </xsl:call-template>
  </xsl:template>
  
  <xsl:template match="daily-values" />
  
  <xsl:template name="superFactTotalValueCalculation">
    <xsl:param name="node"/>
    <xsl:value-of select="sum($node/*) * $quantity div @quantity" />
  </xsl:template>
  
  <xsl:template name="subFactTotalValueCalculation">
    <xsl:param name="node"/>
    <xsl:value-of select="$node * $quantity div @quantity"/>
  </xsl:template>

</xsl:stylesheet>