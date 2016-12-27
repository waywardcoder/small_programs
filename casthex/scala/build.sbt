
lazy val commonSettings = Seq(
  organization := "com.waywardcode",
  version := "1.0",
  scalaVersion := "2.12.1",
  scalacOptions += "-opt:l:classpath" 
)


lazy val castHex = (project in file(".")).
  settings(commonSettings: _*).
  settings(
    name := "castHex"
  )
