'use client'
import Provider from "@/components/theme/Provider"
import Theme from "@/components/theme/Theme"
import { ColorModeScript } from "@chakra-ui/react"
import RootLayout from "./RootLayout"

export default function MainLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      {/*
        <head /> will contain the components returned by the nearest parent
        head.tsx. Find out more at https://beta.nextjs.org/docs/api-reference/file-conventions/head
      */}
      <head />
      <body >
        <Provider>
          <ColorModeScript initialColorMode={Theme.config.initialColorMode}/>
          <RootLayout>{children}</RootLayout>
        </Provider>
      </body>
    </html >
  )
}
