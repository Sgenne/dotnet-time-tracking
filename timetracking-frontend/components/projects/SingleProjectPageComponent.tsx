import styles from "../../styles/projects/SingleProjectPageComponent.module.css"
import Project from "../../types/domain/Project";
import PrimaryButton from "../utils/buttons/PrimaryButton";
import ClockIcon from "../utils/icons/ClockIcon";
import PlusIcon from "../utils/icons/PlusIcon";
import PageContainer from "../utils/PageContainer";
import Table, { TableItem } from "../utils/Table";
import WhiteTopBar from "../utils/WhiteTopBar";

export interface SingleProjectPageComponentProps {
    project: Project;
}


const DUMMY_TABLE_ITEMS: TableItem[] = [{
    content: {
        "title": "Sleepy",
        "duration": 8,
        "notes": "Good sleep :)"
    }
}, {
    content: {
        "title": "Eaty",
        "duration": 1,
        "notes": "So yummy! yum yum!"
    }
}, {
    content: {
        "title": "Trainy",
        "duration": 2,
        "notes": "Wow very strong!"
    }
}]

const SingleProjectPageComponent = ({ project }: SingleProjectPageComponentProps) => <PageContainer>
    <>
        <WhiteTopBar>
            <>
                <h2>{project.title}</h2>
                <div className={styles["button-section"]}>
                    <span className={styles["button-container"]}>
                        <PrimaryButton onClick={() => { }}>
                            <>
                                <ClockIcon />
                                <span className={styles["button-text"]}>
                                    Track activity
                                </span>
                            </>
                        </PrimaryButton>
                    </span>
                    <span className={styles["button-container"]}>
                        <PrimaryButton onClick={() => { }}>
                            <>
                                <PlusIcon />
                                <span className={styles["button-text"]}>
                                    Add activity
                                </span>
                            </>
                        </PrimaryButton>
                    </span>
                </div>
            </>
        </WhiteTopBar>
        <div className={styles["description-section"]}>
            {project.description}
        </div>
        <div className={styles["activities-table"]}>
            <Table tableItems={DUMMY_TABLE_ITEMS} />
        </div>

    </>
</PageContainer>


export default SingleProjectPageComponent