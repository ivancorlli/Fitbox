'use client'

import MenuContentLayout from "@/components/layout/MenuContentLayout"
import { useSession } from "next-auth/react"

export default function Home() {
  const { data: session } = useSession()

  return (
    <>
      <MenuContentLayout>

        <span>
          {session ? session.user?.name : 'nothing'}
        </span>
      </MenuContentLayout>
    </>
  )
}
