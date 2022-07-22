import styles from "../../../styles/navbar/verticalNavbar/VerticalNavbar.module.css"
import ClockIcon from "../../utils/icons/ClockIcon"
import FolderIcon from "../../utils/icons/FolderIcon"
import TagIcon from "../../utils/icons/TagIcon"
import LinkSection, { LinkSectionProps } from "./LinkSection"

const linkSectionProps: LinkSectionProps[] = [
    {
        header: "TRACK",
        links: [
            {
                href: "#",
                linkText: "Timer",
                icon: ClockIcon
            }
        ]
    },
    {
        header: "MANAGE",
        links: [
            {
                href: "#",
                linkText: "Projects",
                icon: FolderIcon
            },
            {
                href: "#",
                linkText: "Tags",
                icon: TagIcon
            }
        ]
    }
]

const VerticalNavbar = () => {
    const linkSections = linkSectionProps.map(props => <li key={props.header + props.links}>
        <LinkSection {...props} />
    </li>)

    return (
        <nav className={styles["navbar"]}>
            <ul className={styles["link-sections"]}>
                {linkSections}
            </ul>
        </nav>
    )
}

export default VerticalNavbar