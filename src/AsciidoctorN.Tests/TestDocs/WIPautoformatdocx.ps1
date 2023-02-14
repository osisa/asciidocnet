$filePath = "D:\osisagit\Staudt\Dokumentation\Dokumentation Staudt AG.adoc.docx" #Filepath (must be absolute)

#Variables for pagebreak
$FindText = "PAGEBREAK" #PAGEBREAK refers to the placeholder in the adoc document
$FindToc = "TABLEOFCONTENTS"
$ReplaceText = "^m" #^m represents a pagebreak

$MatchCase = $true #only full caps gets detected
$MatchWholeWorld = $true #only full word
$MatchWildcards = $false
$MatchSoundsLike = $false
$MatchAllWordForms = $false
$Forward = $false
$Wrap = 1
$Format = $false
$Replace = 2

#Variables for table of contents

$UseFields = $false
$UseHeadingStyles = $true
$LowerHeadingLevel = 9
$UpperHeadingLevel = 1

# Opens the word document
$Word = New-Object -ComObject Word.Application
$word.visible = $true
$doc = $word.documents.open($filePath)

# Replaces PAGEBREAKs with literal pagebreaks
$doc.Content.Find.Execute($FindText, $MatchCase, $MatchWholeWorld, $MatchWildcards, $MatchSoundsLike, $MatchAllWordForms, $Forward, $Wrap, $Format, $ReplaceText, $Replace)

$myRange = $doc.Range(2,3)
# Insert a Table of Contents
$toc = $doc.TablesOfContents.Add($myRange, $UseFields, $UseHeadingStyles, $LowerHeadingLevel, $UpperHeadingLevel)
#$TocRange = $doc.Range(2,2)
#$doc.TablesOfContents.MarkEntry($TocRange, "EntryAutoText")

#$doc.Close(-1)
#$word.quit()
