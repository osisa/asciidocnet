$Docpath = Read-Host "Important:
This Script requires the following programs: Ruby, Asciidoctor, Asciidoctor-Diagram, and Pandoc

Ruby installation: choco install ruby
After installing ruby, restart powershell
Asciidoctor installation: gem install asciidoctor
Asciidoctor-Diagram installation: gem install asciidoctor-diagram
Pandoc installation: choco install pandoc

Enter PATH or name of ASCIIDOC file
For Dokumentation Staudt AG.adoc leave blank"
if ($Docpath -eq "")
{
	$Docpath = "Dokumentation Staudt AG.adoc"
}
asciidoctor -r asciidoctor-diagram -b docbook5 $Docpath -o temp.xml
pandoc --from docbook --to docx temp.xml -o "${Docpath}.docx" --reference-doc="custom-reference.docx"
Remove-Variable -Name Docpath
Remove-Item temp.xml
Remove-Item diag-eb248c02675765bee38716a362484566.svg
Remove-Item .asciidoctor -Recurse
Read-Host "Conversion is done.
Now open the document, press CTRL + H and replace PAGEBREAK^p with ^m
Then Replace TABLEOFCONTENTS with a table of contents"