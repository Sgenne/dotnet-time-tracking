
import styles from "../../../../styles/layouts/navbar/verticalNavbar/LinkSection.module.css";

const LinkSection = () => {
    return (
        <div className={styles["section-container"]}>
            <h5 className={styles["section-header"]}>Track</h5>
            <ul className={styles["links"]}>
                <li>Timer</li>
                <li>Projects</li>
            </ul>
        </div>
    )
}

export default LinkSection