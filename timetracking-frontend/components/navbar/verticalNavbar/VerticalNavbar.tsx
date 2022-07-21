import styles from "../../../styles/navbar/verticalNavbar/VerticalNavbar.module.css"
import LinkSection from "./LinkSection"

const VerticalNavbar = () => {
    return (
        <nav className={styles["navbar"]}>
            <LinkSection />
        </nav>
    )
}

export default VerticalNavbar