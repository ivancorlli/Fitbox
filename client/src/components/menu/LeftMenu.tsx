import FitboxBlue25 from "@/public/icon/FitboxBlue25"
import FitboxWhite25 from "@/public/icon/FitboxWhite25"
import { Avatar, Container, Divider, Icon, IconButton, Popover, PopoverBody, PopoverContent, PopoverTrigger, Portal, Tooltip, useColorMode, VStack } from "@chakra-ui/react"
import { useSession } from "next-auth/react"
import { usePathname, useRouter } from "next/navigation"
import { useEffect, useState } from "react"
import { IconType } from "react-icons"
import { SlFire, SlSettings, SlSupport } from "react-icons/sl"
import RegisterButton from "../button/RegisterButton"
import UserLoggedMenuButton from "./button/UserLoggedMenuButton"




function LeftMenu() {
    const { colorMode } = useColorMode()
    const [image, setImage] = useState<string>()
    const { data: session } = useSession()

    useEffect(() => {
        if (session) {
            if (session.user) {
                if (session.user.image) {
                    setImage(session.user.image)
                }
            }
        } else {
            setImage('https://chakra-ui.com/docs/components/avatar')
        }
    }, [session])

    return (
        <>
            <VStack
                h='100%'
                w='75px'
                spacing={10} paddingY='15px'
                justifyContent='space-between'
                borderRight='1px'
                borderColor={colorMode == 'light' ? 'gray.100' : 'whiteAlpha.200'}
                position='relative'
                top='0'
                left='0'
            >
                <Container >
                    <VStack spacing={6} >
                        <VStack spacing={3}>
                            <Icon as={colorMode == 'light' ? FitboxBlue25 : FitboxWhite25} boxSize={10} />
                            <Divider />
                        </VStack>
                        <VStack spacing={8}>
                            <AsideButton label="Gimnasios" icon={SlFire} link="/" />
                            <AsideButton label="Ayuda" icon={SlSupport} link="/help" />
                            <AsideButton label="Configuracion" icon={SlSettings} link="/settings" />
                        </VStack>
                    </VStack>
                </Container>
                {/* Footer */}
                <Container>
                    <VStack spacing={3}>

                        <Divider />
                        <Popover
                            placement='top'
                        >
                            <PopoverTrigger>
                                <Avatar
                                    size='sm'
                                    _hover={{ cursor: 'pointer' }}
                                    src={image}
                                />
                            </PopoverTrigger>
                            <Portal>
                                <PopoverContent
                                    borderRadius='10px'
                                    paddingY='5px'
                                    marginLeft='25px'
                                >
                                    <PopoverBody>
                                        {
                                            session ?
                                                <UserLoggedMenuButton />
                                                :
                                                <RegisterButton />
                                        }
                                    </PopoverBody>
                                </PopoverContent>
                            </Portal>
                        </Popover>
                    </VStack>
                </Container>
            </VStack>
        </>
    )

}
export default LeftMenu


function AsideButton({ label, icon, link }: { label: string, icon: IconType, link: string }) {
    const { push } = useRouter()
    const path = usePathname()
    function handleActive() {
        let response = ''
        if (path != null) {
            if (path == '/') response = '/'
            const child = path.split('/')
            if (child) {
                response = `/${child[1].toString()}`
            } else {
                response = '/'
            }
        } else {
            response = ''
        }
        return response
    }
    return (
        <Tooltip label={label}>
            <Icon
                as={icon}
                onClick={() => push(link)}
                boxSize={7}
                color={handleActive() == link ? 'blue.400' : ''}
            />
        </Tooltip>
    )
}