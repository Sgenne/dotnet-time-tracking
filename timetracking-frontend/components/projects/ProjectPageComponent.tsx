import { JSXElementConstructor, ReactElement } from "react";
import styles from "../../styles/projects/ProjectPageComponent.module.css";
import PrimaryButton from "../utils/buttons/PrimaryButton";
import PlusIcon from "../utils/icons/PlusIcon";
import Table from "../utils/Table";

const DUMMY_TABLE_ITEMS: { [key: string]: string | ReactElement<any, string | JSXElementConstructor<any>>; }[]
    = [{
        Project: "AG",
        "Time Status": "7h",
        Team: "Simon"
    }, 
    {
        Project: "Kandidatarbete",
        "Time Status": "141h",
        Team: "Simon"
    }, 
    {
        Project: "Software Analysis and Design",
        "Time Status": "7h",
        Team: "Simon"
    }]

const ProjectPageComponent = () => {
    return (
        <div className={styles["page-container"]}>
            <div className={styles["top-bar"]}>
                <h2>Projects</h2>
                <span className={styles["new-project-button-container"]}>
                    <PrimaryButton onClick={() => { }}>
                        <>
                            <PlusIcon />
                            <span className={styles["new-project-button__text"]}>New Project</span>
                        </>
                    </PrimaryButton>
                </span>
            </div>
            <div className={styles["projects-list"]}>
                <Table tableItems={DUMMY_TABLE_ITEMS} />
            </div>
        </div>
    )
}

export default ProjectPageComponent